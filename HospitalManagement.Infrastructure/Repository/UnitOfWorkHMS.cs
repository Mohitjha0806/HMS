using HospitalManagement.Data;
using HospitalManagement.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Infrastructure.Repository
{

    public class UnitOfWorkHMS : IUnitOfWorkHMS
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWorkHMS(ApplicationDbContext context)
        {
            _context = context;
        }

        public IMstHospitalRegistrationRepository MstHospitalRegistrationRepository => new MstHospitalRegistrationRepository(_context);

    }
}
