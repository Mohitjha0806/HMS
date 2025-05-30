using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Entities.ViewModel
{
    public class HospitalTypeVM
    {
        [Key]
        public int HospitalTypeId { get; set; }
        public required string HospitalTypeName { get; set; }
        public bool IsActive { get; set; }
    }
}
