using HospitalManagement.Data;
using HospitalManagement.Entities.Models;
using HospitalManagement.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Infrastructure.Repository
{
    public class MstHospitalRegistrationRepository : IMstHospitalRegistrationRepository
    {
        private readonly ApplicationDbContext _context;

        public MstHospitalRegistrationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task InsertMstHospitalRegister(MstHospitalRegistration mstHospitalRegistration)
        {
            try
            {
                await _context.AddAsync(mstHospitalRegistration);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<HospitalTypeModel> BindHospitaltype()
        {
            try
            {
                return _context.HospitalTypeModel.ToList();

            }
            catch (Exception)
            {
                throw;
            }
        }

    }

}
