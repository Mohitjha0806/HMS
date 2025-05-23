using HospitalManagement.Entities.ViewModel;
using HospitalManagement.Entities.Models;
using HospitalManagement.Infrastructure.Contracts;
using HospitalManagement.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.BusinessLayer.HospitalManagementBAL.MastersBAL
{
    public class MstHospitalRegistrationBAL
    {
        private readonly Infrastructure.Contracts.IUnitOfWorkHMS _unitOfWork;


        public MstHospitalRegistrationBAL(Infrastructure.Contracts.IUnitOfWorkHMS unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task InsertMstHospitalRegister(MstHospitalRegistration mstHospitalRegistration)
        {
             await _unitOfWork.MstHospitalRegistrationRepository.InsertMstHospitalRegister(mstHospitalRegistration);
        }
        public IEnumerable<HospitalTypeModel> GetHospitalTypes()
        {
            try
            {
                var hospitalTypes = _unitOfWork.MstHospitalRegistrationRepository.BindHospitaltype();
                return hospitalTypes;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in BAL: {ex.Message}");
                throw new ApplicationException("Failed to fetch hospital types.", ex);
            }
        }

        public List<MstHospitalRegistrationVM> GetAllHospitals()
        {
            try
            {
                return _unitOfWork.MstHospitalRegistrationRepository.GetAllHospitals();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in BAL: {ex.Message}");
                throw new ApplicationException("Failed to fetch all hospitals.", ex);
            }
        }

        public MstHospitalRegistrationVM GetHospitalById(int hospitalId)
        {
            try
            {
                var hospital = _unitOfWork.MstHospitalRegistrationRepository.GetHospitalById(hospitalId);

                if (hospital == null)
                {
                    throw new Exception("Hospital not found.");
                }

                return hospital;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in BAL: {ex.Message}");
                throw new ApplicationException("Failed to fetch hospital by ID.", ex);
            }
        }




        public void UpdateHospital(int hospitalId, MstHospitalRegistrationVM mstHospitalRegistrationVM)
        {
            try
            {
                // Retrieve the existing hospital data
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
                    ContactNumber = mstHospitalRegistrationVM.ContactNumber
                };

                _unitOfWork.MstHospitalRegistrationRepository.UpdateHospital(hospitalEntity, mstHospitalRegistrationVM);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating hospital details: {ex.Message}", ex);
            }
        }


    }
}

