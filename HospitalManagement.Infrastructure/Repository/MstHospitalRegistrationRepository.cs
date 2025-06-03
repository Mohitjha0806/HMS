using HospitalManagement.Data;
using HospitalManagement.Entities.Models;
using HospitalManagement.Entities.ViewModel;
using HospitalManagement.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task InsertMstHospitalRegister(MstHospitalRegistrationVM mstHospitalRegistrationVM)
        {
            var entity = new MstHospitalRegistration
            {
                HospitalName = mstHospitalRegistrationVM.HospitalName,
                HospitalTypeId = mstHospitalRegistrationVM.HospitalTypeId,
                OwnerName = mstHospitalRegistrationVM.OwnerName,
                MedicalLicenseNumber = mstHospitalRegistrationVM.MedicalLicenseNumber,
                StaffCount = mstHospitalRegistrationVM.StaffCount,
                Address = mstHospitalRegistrationVM.Address,
                Email = mstHospitalRegistrationVM.Email,
                ContactNumber = mstHospitalRegistrationVM.ContactNumber,
                DivisionId = mstHospitalRegistrationVM.DivisionId,
                DistrictId = mstHospitalRegistrationVM.DistrictId,
                BlockId = mstHospitalRegistrationVM.BlockId,
                IsActive = mstHospitalRegistrationVM.IsActive
            };

            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public IEnumerable<HospitalTypeModel> BindHospitaltype()
        {
            return _context.HospitalTypeModel
                .Where(h => h.IsActive == true)
                .ToList();
        }

        public List<MstHospitalRegistrationVM> GetAllHospitals()
        {
            return (from mhms in _context.MstHospitalRegistration
                    join htm in _context.HospitalTypeModel
                    on mhms.HospitalTypeId equals htm.HospitalTypeId
                    join mds in _context.MstDivision
                    on mhms.DivisionId equals mds.DivisionId
                    join mdist in _context.MstDistrict
                    on mhms.DistrictId equals mdist.DistrictId
                    join mBlock in _context.MstBlock
                    on mhms.BlockId equals mBlock.BlockId
                    orderby mhms.HospitalId descending
                    select new MstHospitalRegistrationVM
                    {
                        HospitalId = mhms.HospitalId,
                        HospitalName = mhms.HospitalName,
                        HospitalTypeName = htm.HospitalTypeName,
                        OwnerName = mhms.OwnerName,
                        MedicalLicenseNumber = mhms.MedicalLicenseNumber,
                        StaffCount = mhms.StaffCount,
                        Address = mhms.Address,
                        Email = mhms.Email,
                        ContactNumber = mhms.ContactNumber,
                        DivisionName = mds.DivisionName,
                        DistrictName = mdist.DistrictName,
                        BlockName = mBlock.BlockName,
                        IsActive = mhms.IsActive
                    }).ToList();
        }

        public MstHospitalRegistrationVM GetHospitalById(int hospitalId, int divisionId, int districtId, int blockId,)
        {
            return (from mhms in _context.MstHospitalRegistration
                    where mhms.HospitalId == hospitalId
                    select new MstHospitalRegistrationVM
                    {
                        HospitalId = mhms.HospitalId,
                        HospitalName = mhms.HospitalName,
                        HospitalTypeId = mhms.HospitalTypeId,
                        OwnerName = mhms.OwnerName,
                        MedicalLicenseNumber = mhms.MedicalLicenseNumber,
                        StaffCount = mhms.StaffCount,
                        Address = mhms.Address,
                        Email = mhms.Email,
                        ContactNumber = mhms.ContactNumber,
                        DivisionId = mhms.DivisionId,
                        DistrictId = mhms.DistrictId,
                        BlockId = mhms.BlockId,
                        IsActive = mhms.IsActive
                    }).FirstOrDefault() ?? throw new InvalidOperationException($"Hospital with ID {hospitalId} not found.");
        }

        public async Task UpdateHospital(MstHospitalRegistration mstHospitalRegistration, MstHospitalRegistrationVM mstHospitalRegistrationVM)
        {
            _context.MstHospitalRegistration.Update(mstHospitalRegistration);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteHospital(int hospitalId)
        {

            var hospital = await _context.MstHospitalRegistration.FindAsync(hospitalId);
            try
            {
                if (hospital != null)
                {
                    _context.MstHospitalRegistration.Remove(hospital);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }


        }

        public List<MstDivision> GetDivisions()
        {
            return _context.MstDivision
                .Where(h => h.IsActive == true)
                .ToList();
        }

        public List<MstDistrict> GetDistricts(int DivisionId)
        {
            return _context.MstDistrict
                .Where(d => d.DivisionId == DivisionId)
                .Select(d => new MstDistrict
                {
                    DistrictId = d.DistrictId,
                    DistrictName = d.DistrictName,
                    IsActive = d.IsActive,
                    DivisionId = d.DivisionId
                })
                .ToList();
        }
        public List<MstBlock> GetBlocks(int DistrictId)
        {
            return _context.MstBlock
                .Where(d => d.DistrictId == DistrictId)
                .Select(d => new MstBlock
                {
                    BlockId = d.BlockId,
                    BlockName = d.BlockName,
                    IsActive = d.IsActive,
                    DistrictId = d.DistrictId
                })
                .ToList();
        }

    }
}
