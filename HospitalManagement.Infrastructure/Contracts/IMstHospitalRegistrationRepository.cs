using HospitalManagement.Entities.ViewModel;
using HospitalManagement.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagement.Infrastructure.Contracts
{
    public interface IMstHospitalRegistrationRepository
    {
        Task InsertMstHospitalRegister(MstHospitalRegistrationVM mstHospitalRegistrationVM);
        IEnumerable<HospitalTypeModel> BindHospitaltype();
        List<MstHospitalRegistrationVM> GetAllHospitals();
        MstHospitalRegistrationVM GetHospitalById(int hospitalId);
        Task UpdateHospital(MstHospitalRegistration mstHospitalRegistration, MstHospitalRegistrationVM mstHospitalRegistrationVM);
        public Task DeleteHospital(int hospitalId);
    }
}
