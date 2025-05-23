using HospitalManagement.BusinessLayer.HospitalManagementBAL.MastersBAL;
using HospitalManagement.Data;
using HospitalManagement.Entities.Models;
using HospitalManagement.Entities.ViewModel;
using HospitalManagement.Infrastructure.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolEducationPortal.Utilities;

namespace HospitalManagement.Web.Controllers.HospitalManagement.Master
{
    public class MstHospitalRegistrationController : Controller
    {
        private readonly MstHospitalRegistrationBAL _mstHospitalRegistrationBAL;
        private readonly IUnitOfWorkHMS _unitOfWork;
        private readonly ApplicationDbContext _context;

        public MstHospitalRegistrationController(
            MstHospitalRegistrationBAL mstHospitalRegistrationBAL,
            IUnitOfWorkHMS unitOfWork,
            ApplicationDbContext context)
        {
            _mstHospitalRegistrationBAL = mstHospitalRegistrationBAL;
            _unitOfWork = unitOfWork;
            _context = context;
        }

        public IActionResult Index()
        {
            GetAllHospitals();
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var hospitalTypes = _mstHospitalRegistrationBAL.GetHospitalTypes();
            ViewBag.HospitalTypes = new SelectList(hospitalTypes, "HospitalTypeID", "HospitalTypeName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(MstHospitalRegistration mstHospitalRegistration)
        {
            try
            {
                await _mstHospitalRegistrationBAL.InsertMstHospitalRegister(mstHospitalRegistration);
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
    }
}
