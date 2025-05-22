using HospitalManagement.Entities.ViewModel;
using HospitalManagement.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace HospitalManagement.Infrastructure.Contracts
{
    public interface IMstHospitalRegistrationRepository
    {
        public Task InsertMstHospitalRegister(MstHospitalRegistration mstHospitalRegistration);

        public IEnumerable<HospitalTypeModel> BindHospitaltype();
        public List<MstHospitalRegistrationVM> GetAllHospitals();
        public  List<MstHospitalRegistrationVM> GetHospitalById(int hospitalId);
        public Task UpdateHospital(MstHospitalRegistration mstHospitalRegistration, MstHospitalRegistrationVM mstHospitalRegistrationVM);
    }
}
