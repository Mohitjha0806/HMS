using HospitalManagement.Data;
using HospitalManagement.Entities.Models;
using HospitalManagement.Entities.ViewModel;
using HospitalManagement.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Infrastructure.Repository
{
    public class MstHospitalTypeRepository : IMstHospitalType
    {
        private readonly ApplicationDbContext _context;
        public MstHospitalTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task InsertMstHospitalType(HospitalTypeVM hospitalTypeVM)
        {
            var entity = new HospitalTypeModel
            {
                HospitalTypeName = hospitalTypeVM.HospitalTypeName,
                IsActive = hospitalTypeVM.IsActive
            };

            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public List<HospitalTypeVM> GetAllHospitalType()
        {
            return (from mhms in _context.HospitalTypeModel
                    orderby mhms.HospitalTypeId descending
                    select new HospitalTypeVM
                    {
                        HospitalTypeId = mhms.HospitalTypeId,
                        HospitalTypeName = mhms.HospitalTypeName,
                        IsActive = mhms.IsActive
                    }).ToList();
        }
        public HospitalTypeVM GetHospitalTypeById(int hospitalTypeId)
        {
            return (from mhms in _context.HospitalTypeModel
                    where mhms.HospitalTypeId == hospitalTypeId
                    select new HospitalTypeVM
                    {
                        HospitalTypeId = mhms.HospitalTypeId,
                        HospitalTypeName = mhms.HospitalTypeName,
                        IsActive = mhms.IsActive
                    }).FirstOrDefault() ?? throw new InvalidOperationException($"Hospital with ID {hospitalTypeId} not found.");
        }

        public async Task UpdateHospital(HospitalTypeVM hospitalTypeVM)
        {
            var entity = await _context.HospitalTypeModel.FirstOrDefaultAsync(h => h.HospitalTypeId == hospitalTypeVM.HospitalTypeId);
            if (entity == null)
            {
                throw new InvalidOperationException($"Hospital with ID {hospitalTypeVM.HospitalTypeId} not found.");
            }

            entity.HospitalTypeName = hospitalTypeVM.HospitalTypeName;
            entity.IsActive = hospitalTypeVM.IsActive;

            _context.HospitalTypeModel.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
