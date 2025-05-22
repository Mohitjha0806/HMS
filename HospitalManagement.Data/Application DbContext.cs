using Microsoft.EntityFrameworkCore;    
using HospitalManagement.Entities.Models;
using HospitalManagement.Entities.ViewModel;
namespace HospitalManagement.Data
{
    public partial class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
        
        }
        public DbSet<MstHospitalRegistration> MstHospitalRegistration { get; set; }
        public DbSet<HospitalTypeModel> HospitalTypeModel { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MstHospitalRegistration>(entity =>
            {
                entity.ToTable("MstHospitalRegistration");
            });

            modelBuilder.Entity<HospitalTypeModel>(entity =>
            {
                entity.ToTable("HospitalTypeModel");
            });
        }
    }

}




