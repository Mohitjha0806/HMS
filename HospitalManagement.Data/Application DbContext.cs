using Microsoft.EntityFrameworkCore;    
using HospitalManagement.Entities.Models;
using HospitalManagement.Entities.ViewModel;
namespace HospitalManagement.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
        
        }
        public DbSet<MstHospitalRegistration> MstHospitalRegistration { get; set; }
        public DbSet<HospitalTypeModel> HospitalTypeModel { get; set; }
        public DbSet<MstDivision> MstDivision { get; set; }
        public DbSet<MstDistrict> MstDistrict { get; set; }
        //public DbSet<MstBlock> MstBlock { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }
    }

}




