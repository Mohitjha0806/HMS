using HospitalManagement.Entities.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Infrastructure.Contracts
{
    public interface IMstHospitalType
    {
        Task InsertMstHospitalType(HospitalTypeVM hospitalTypeVM);
        List<HospitalTypeVM> GetAllHospitalType();

        public HospitalTypeVM GetHospitalTypeById(int hospitalTypeId);
        public  Task UpdateHospital(HospitalTypeVM hospitalTypeVM);
    }
}
