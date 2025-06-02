using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Entities.Models
{
    public class MstHospitalRegistration
    {
        [Key]
        public int HospitalId { get; set; }

        [StringLength(100)]
        public required string HospitalName { get; set; }

        [Required]
        public int HospitalTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public required string OwnerName { get; set; }

        [Required]
        [StringLength(10)]
        [RegularExpression(@"[1-9]{1}[0-9]{9}", ErrorMessage = "Medical License Number must be 10 digits.")]
        public required string MedicalLicenseNumber { get; set; }

        [Required]
        [Range(0, 50)]
        public int StaffCount { get; set; }

        [Required]
        [StringLength(200)]
        public required string Address { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [Phone]
        [StringLength(15)]
        public required string ContactNumber { get; set; }

        public  int DivisionId { get; set; }
        public  int DistrictId { get; set; }
        public  int BlockId { get; set; }

        public bool IsActive { get; set; }
    }
}




