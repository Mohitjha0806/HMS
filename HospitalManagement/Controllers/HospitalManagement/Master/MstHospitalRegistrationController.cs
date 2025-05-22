using HospitalManagement.BusinessLayer.HospitalManagementBAL.MastersBAL;
using HospitalManagement.Data;
using HospitalManagement.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var hospitalTypes = await Task.FromResult(_mstHospitalRegistrationBAL.GetHospitalTypes());
            //ViewBag.HospitalTypes = hospitalTypes;
            ViewBag.HospitalTypes = new SelectList(hospitalTypes, "HospitalTypeID", "HospitalTypeName");
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> CreatePost(MstHospitalRegistration mstHospitalRegistration)
        {
            await _mstHospitalRegistrationBAL.InsertMstHospitalRegister(mstHospitalRegistration);
            return RedirectToAction("Index");
        }

        public IActionResult Edit()
        {
            return View();
        }
    }
}
