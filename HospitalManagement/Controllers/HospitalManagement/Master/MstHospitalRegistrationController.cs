using HospitalManagement.BusinessLayer.HospitalManagementBAL.MastersBAL;
using HospitalManagement.Data;
using HospitalManagement.Entities.ViewModel;
using HospitalManagement.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolEducationPortal.Utilities;

namespace HospitalManagement.Web.Controllers.HospitalManagement.Master
{
    public class MstHospitalRegistrationController : Controller
    {
        private readonly MstHospitalRegistrationBAL _mstHospitalRegistrationBAL;
        private readonly Infrastructure.Contracts.IUnitOfWorkHMS _unitOfWork;
        private readonly ApplicationDbContext _context;

        public MstHospitalRegistrationController(
            MstHospitalRegistrationBAL mstHospitalRegistrationBAL,
            Infrastructure.Contracts.IUnitOfWorkHMS unitOfWork,
            ApplicationDbContext context)
        {
            _mstHospitalRegistrationBAL = mstHospitalRegistrationBAL;
            _unitOfWork = unitOfWork;
            _context = context;
        }

        public IActionResult Index()
        {
            Task.FromResult(GetAllHospitals());
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var hospitalTypes = await Task.FromResult(_mstHospitalRegistrationBAL.GetHospitalTypes());
            ViewBag.HospitalTypes = new SelectList(hospitalTypes, "HospitalTypeID", "HospitalTypeName");

            return View();
        }



        [HttpPost]
        public async Task<IActionResult> CreatePost(MstHospitalRegistration mstHospitalRegistration)
        {
            try
            {
                await _mstHospitalRegistrationBAL.InsertMstHospitalRegister(mstHospitalRegistration);
                TempData["Message"] = AlertMessageEnum.GetEnumDisplayName(AlertMessageEnum.AlertMsg.updatetMsg);
                TempData["Type"] = (int)AlertMessageEnum.AlertCode.sucessCode;
                return RedirectToAction("Create");

            }
            catch (Exception)
            {

                TempData["ErrorMessage"] = "Something went wrong!";
                throw;
            }
        }

        [HttpGet]
        public IActionResult Edit(int hospitalId, MstHospitalRegistrationVM mstHospitalRegistrationVM)
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

            return View(result);
        }




        [HttpPost]
        public IActionResult UpdateHospital(int hospitalId, MstHospitalRegistrationVM mstHospitalRegistrationVM)
             {
            //int hospitalId = mstHospitalRegistrationVM.HospitalId;
            if (!ModelState.IsValid)
            {
                return View(mstHospitalRegistrationVM);
            }

            try
            {
                _mstHospitalRegistrationBAL.UpdateHospital(hospitalId, mstHospitalRegistrationVM);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error updating hospital: {ex.Message}");
                return View(mstHospitalRegistrationVM);
            }
        }




        [HttpGet]
        public async Task<IActionResult> GetAllHospitals()
        {
            var hospitals = await Task.FromResult(_mstHospitalRegistrationBAL.GetAllHospitals());
            return View(hospitals);
        }   

    }
}
