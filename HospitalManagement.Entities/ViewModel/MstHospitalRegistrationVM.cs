using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Entities.ViewModel
{
    public class MstHospitalRegistrationVM
    {

        public int HospitalId { get; set; }

        public required string HospitalName { get; set; }

        public int HospitalType { get; set; }
        public int HospitalTypeId{get; set;}

        public string? HospitalTypeName { get; set;}
        public required string OwnerName { get; set; }
        public required string MedicalLicenseNumber { get; set; }

        public int StaffCount { get; set; }

        public required string Address { get; set; }

        public required string Email { get; set; }

        public required string ContactNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
