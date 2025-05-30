using HospitalManagement.Entities.Models;
using HospitalManagement.Entities.ViewModel;
using HospitalManagement.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.BusinessLayer.HospitalManagementBAL.MastersBAL
{
    public class HospitalTypeBAL
    {
        private readonly UnitOfWorkHMS _unitOfWorkHMS;

        public HospitalTypeBAL(UnitOfWorkHMS unitOfWorkHMS)
        {
            _unitOfWorkHMS = unitOfWorkHMS;
        }

        public async Task InsertHospitaltype(HospitalTypeVM mstHospitalTypeVM)
        {
            await _unitOfWorkHMS.MstHospitalTypeRepository.InsertMstHospitalType(mstHospitalTypeVM);
        }

        public List<HospitalTypeVM> GetAllHospitalType()
        {
            return _unitOfWorkHMS.MstHospitalTypeRepository.GetAllHospitalType();
        }

        public HospitalTypeVM GetHospitalTypeById(int hospitalTypeId)
        {
            var hospitalType = _unitOfWorkHMS.MstHospitalTypeRepository.GetHospitalTypeById(hospitalTypeId);
            if (hospitalType == null)
            {
                throw new Exception("Hospital not found.");
            }
            return hospitalType;
        }

        public async Task UpdateHospital(int hospitalTypeId, HospitalTypeVM hospitalTypeVM)
        {
            var existingHospital = _unitOfWorkHMS.MstHospitalTypeRepository.GetHospitalTypeById(hospitalTypeId);
            if (existingHospital == null)
            {
                throw new Exception("Hospital not found for update.");
            }

            if (hospitalTypeVM.HospitalTypeName == null)
            {
                throw new ArgumentNullException(nameof(hospitalTypeVM.HospitalTypeName), "HospitalTypeName cannot be null.");
            }

            var hospitalTypeEntity = new HospitalTypeVM
            {
                HospitalTypeId = hospitalTypeVM.HospitalTypeId,
                HospitalTypeName = hospitalTypeVM.HospitalTypeName,
                IsActive = hospitalTypeVM.IsActive
            };

            await _unitOfWorkHMS.MstHospitalTypeRepository.UpdateHospital(hospitalTypeEntity);
        }
    }
}
