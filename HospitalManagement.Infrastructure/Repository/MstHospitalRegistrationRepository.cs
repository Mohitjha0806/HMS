using HospitalManagement.Data;
using HospitalManagement.Entities.Models;
using HospitalManagement.Entities.ViewModel;
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

        public List<MstHospitalRegistrationVM> GetAllHospitals()
        {
            try
            {
                var result = (from mhms in _context.MstHospitalRegistration
                              join htm in _context.HospitalTypeModel
                              on mhms.HospitalTypeId equals htm.HospitalTypeID
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
                                  ContactNumber = mhms.ContactNumber
                              }).ToList();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public MstHospitalRegistrationVM GetHospitalById(int hospitalId)
        {
            try
            {
                var result = (from mhms in _context.MstHospitalRegistration
                              join htm in _context.HospitalTypeModel
                              on mhms.HospitalTypeId equals htm.HospitalTypeID
                              where mhms.HospitalId == hospitalId
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
                                  ContactNumber = mhms.ContactNumber
                              }).FirstOrDefault();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving hospital by ID: {ex.Message}", ex);
            }
        }



        public async Task UpdateHospital(MstHospitalRegistration mstHospitalRegistration, MstHospitalRegistrationVM mstHospitalRegistrationVM)
        {
            try
            {
                _context.MstHospitalRegistration.Update(mstHospitalRegistration);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }

}
