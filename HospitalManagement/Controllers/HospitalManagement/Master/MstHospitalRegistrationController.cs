using HospitalManagement.BusinessLayer.HospitalManagementBAL.MastersBAL;
using HospitalManagement.Data;
using HospitalManagement.Entities.Models;
using HospitalManagement.Entities.ViewModel;
using HospitalManagement.Infrastructure.Contracts;
using HospitalManagement.Utilities.enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Web.Controllers.HospitalManagement.Master
{
    public class MstHospitalRegistrationController : Controller
    {
        private readonly MstHospitalRegistrationBAL _mstHospitalRegistrationBAL;
        private readonly IUnitOfWorkHMS _unitOfWork;

        public MstHospitalRegistrationController(
            MstHospitalRegistrationBAL mstHospitalRegistrationBAL,
            IUnitOfWorkHMS unitOfWork)
        {
            _mstHospitalRegistrationBAL = mstHospitalRegistrationBAL;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            GetAllHospitals();
            return View();
        }

        [HttpGet]
        public IActionResult Create(int DivisionId, int DistrictId)
        {
            var hospitalTypes = _mstHospitalRegistrationBAL.GetHospitalTypes();
            var divisions = _mstHospitalRegistrationBAL.GetDivision();
            var districts = _mstHospitalRegistrationBAL.GetDistrict(DivisionId);
            var blocks = _mstHospitalRegistrationBAL.GetBlock(DistrictId);

            ViewBag.HospitalTypes = new SelectList(hospitalTypes, "HospitalTypeId", "HospitalTypeName");
            ViewBag.Divisions = new SelectList(divisions, "DivisionId", "DivisionName");
            ViewBag.Districts = new SelectList(districts, "DistrictId", "DistrictName");
            ViewBag.Blocks = new SelectList(blocks, "BlockId", "BlockName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(MstHospitalRegistrationVM mstHospitalRegistrationVM)
        {
            try
            {
                await _mstHospitalRegistrationBAL.InsertMstHospitalRegister(mstHospitalRegistrationVM);
                TempData["Message"] = AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.insertMsg);
                TempData["Type"] = (int)AlertMessageEnum.AlertCode.sucessCode;
                return RedirectToAction("Create");
            }
            catch (Exception)
            {
                TempData["Message"] = AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.alreadyMsg);
                TempData["Type"] = (int)AlertMessageEnum.AlertCode.WarningCode;
                TempData["ErrorMessage"] = "Something went wrong!";
                throw;
            }
        }

        [HttpGet]
        public IActionResult Edit(int hospitalId)
        {
            if (hospitalId <= 0)
            {
                return BadRequest("Invalid hospital ID.");
            }

            var result = _mstHospitalRegistrationBAL.GetHospitalById(hospitalId);
            if (result == null)
            {
                return NotFound("Hospital not found.");
            }

            var hospitalTypes = _mstHospitalRegistrationBAL.GetHospitalTypes();
            ViewBag.HospitalTypes = hospitalTypes;

            var divisions = _mstHospitalRegistrationBAL.GetDivision();
            ViewBag.Division = divisions;

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateHospital(int hospitalId, MstHospitalRegistrationVM mstHospitalRegistrationVM)
        {
            if (!ModelState.IsValid)
            {
                return View(mstHospitalRegistrationVM);
            }

            try
            {
                await _mstHospitalRegistrationBAL.UpdateHospital(hospitalId, mstHospitalRegistrationVM);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error updating hospital: {ex.Message}");
                return View(mstHospitalRegistrationVM);
            }
        }

        [HttpGet]
        public IActionResult GetAllHospitals()
        {
            var hospitals = _mstHospitalRegistrationBAL.GetAllHospitals();
            return View(hospitals);
        }

        public IActionResult Delete(int hospitalId)
        {
            try
            {
                var deleteTask = _mstHospitalRegistrationBAL.DeleteHospital(hospitalId);
                deleteTask.Wait(); 
                bool isDeleted = deleteTask.IsCompletedSuccessfully;

                if (!isDeleted)
                {
                    return NotFound(new { message = "Hospital not found." });
                }
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"An error occurred: {ex.Message}" });
            }
        }



        [HttpGet]
        public IActionResult GetAllDivision()
        {
            var divisions = _mstHospitalRegistrationBAL.GetDivision();
            return View(divisions);
        }


        [HttpGet]
        public JsonResult GetAllDistrict(int DivisionId)
        {
            var districts = _mstHospitalRegistrationBAL.GetDistrict(DivisionId);
            return Json(districts);
        }

        [HttpGet]
        public JsonResult GetAllBlock(int DistrictId)
        {
            var blocks = _mstHospitalRegistrationBAL.GetBlock(DistrictId);
            return Json(blocks);
        }
    }
}
