using HospitalManagement.BusinessLayer.HospitalManagementBAL.MastersBAL;
using HospitalManagement.Entities.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Web.Controllers.HospitalManagement.Master
{
    public class MstHospitalTypeController : Controller
    {
        private readonly HospitalTypeBAL _hospitalTypeBAL;

        public MstHospitalTypeController(HospitalTypeBAL hospitalTypeBAL)
        {
            _hospitalTypeBAL = hospitalTypeBAL;
        }

        public IActionResult Index()
        {
            var hospitaltype = _hospitalTypeBAL.GetAllHospitalType();
            return View(hospitaltype);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(HospitalTypeVM mstHospitalTypeVM)
        {
            try
            {
                await _hospitalTypeBAL.InsertHospitaltype(mstHospitalTypeVM);
                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public IActionResult Edit(int hospitaltypeId)
        {
            if (hospitaltypeId <= 0)
            {
                return BadRequest("Invalid hospital ID.");
            }

            var result = _hospitalTypeBAL.GetHospitalTypeById(hospitaltypeId);
            if (result == null)
            {
                return NotFound("Hospital not found.");
            }

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateHospital(int hospitaltypeId, HospitalTypeVM hospitalTypeVM)
        {
            if (!ModelState.IsValid)
            {
                return View(hospitalTypeVM);
            }

            try
            {
                var hospitalType = new HospitalTypeVM
                {
                    HospitalTypeId = hospitalTypeVM.HospitalTypeId,
                    HospitalTypeName = hospitalTypeVM.HospitalTypeName,
                    IsActive = hospitalTypeVM.IsActive,
                   
                };

                await _hospitalTypeBAL.UpdateHospital(hospitaltypeId, hospitalTypeVM);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error updating hospital: {ex.Message}");
                return View(hospitalTypeVM);
            }
        }
    }
}
