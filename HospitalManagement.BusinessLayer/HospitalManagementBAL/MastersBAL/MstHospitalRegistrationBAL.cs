using HospitalManagement.Entities.ViewModel;
using HospitalManagement.Entities.Models;
using HospitalManagement.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections;

namespace HospitalManagement.BusinessLayer.HospitalManagementBAL.MastersBAL
{
    public class MstHospitalRegistrationBAL
    {
        private readonly IUnitOfWorkHMS _unitOfWork;

        public MstHospitalRegistrationBAL(IUnitOfWorkHMS unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task InsertMstHospitalRegister(MstHospitalRegistrationVM mstHospitalRegistrationVM)
        {
            await _unitOfWork.MstHospitalRegistrationRepository.InsertMstHospitalRegister(mstHospitalRegistrationVM);
        }

        public IEnumerable<HospitalTypeModel> GetHospitalTypes()
        {
            return _unitOfWork.MstHospitalRegistrationRepository.BindHospitaltype();
        }

        public List<MstHospitalRegistrationVM> GetAllHospitals()
        {
            return _unitOfWork.MstHospitalRegistrationRepository.GetAllHospitals();
        }

        public MstHospitalRegistrationVM GetHospitalById(int hospitalId)
        {
            var hospital = _unitOfWork.MstHospitalRegistrationRepository.GetHospitalById(hospitalId);
            if (hospital == null)
            {
                throw new Exception("Hospital not found.");
            }
            return hospital;
        }

        public async Task UpdateHospital(int hospitalId, MstHospitalRegistrationVM mstHospitalRegistrationVM)
        {
            var existingHospital = _unitOfWork.MstHospitalRegistrationRepository.GetHospitalById(hospitalId);
            if (existingHospital == null)
            {
                throw new Exception("Hospital not found for update.");
            }

            var hospitalEntity = new MstHospitalRegistration
            {
                HospitalId = hospitalId,
                HospitalName = mstHospitalRegistrationVM.HospitalName,
                HospitalTypeId = mstHospitalRegistrationVM.HospitalTypeId,
                Address = mstHospitalRegistrationVM.Address,
                OwnerName = mstHospitalRegistrationVM.OwnerName,
                MedicalLicenseNumber = mstHospitalRegistrationVM.MedicalLicenseNumber,
                StaffCount = mstHospitalRegistrationVM.StaffCount,
                Email = mstHospitalRegistrationVM.Email,
                ContactNumber = mstHospitalRegistrationVM.ContactNumber,
                DivisionId = mstHospitalRegistrationVM.DivisionId,
                IsActive = mstHospitalRegistrationVM.IsActive
            };

            await _unitOfWork.MstHospitalRegistrationRepository.UpdateHospital(hospitalEntity, mstHospitalRegistrationVM);
        }
        public async Task DeleteHospital(int hospitalId)
        {
            try
            {
                await _unitOfWork.MstHospitalRegistrationRepository.DeleteHospital(hospitalId);

            }
            catch (Exception)
            {

                throw;
            }
        }


        public List<MstDivision> GetDivision()
        {
            return _unitOfWork.MstHospitalRegistrationRepository.GetDivisions();
        }
        public IEnumerable GetDistrict(int DivisionId)
        {
            return _unitOfWork.MstHospitalRegistrationRepository.GetDistricts(DivisionId);
        }
        public IEnumerable GetBlock(int DistrictId)
        {
            return _unitOfWork.MstHospitalRegistrationRepository.GetBlocks(DistrictId);
        }
    }
}