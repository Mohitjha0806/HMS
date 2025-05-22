using HospitalManagement.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Infrastructure.Contracts
{
    public interface IMstHospitalRegistrationRepository
    {
        public Task InsertMstHospitalRegister(MstHospitalRegistration mstHospitalRegistration);

        public IEnumerable<HospitalTypeModel> BindHospitaltype();
    }
}
