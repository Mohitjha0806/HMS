using HospitalManagement.Entities.Models;
using HospitalManagement.Infrastructure.Contracts;
using HospitalManagement.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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



    }
}
