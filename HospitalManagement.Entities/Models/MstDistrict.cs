using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Entities.Models
{
    public class MstDistrict
    {
        [Key]
        public int DistrictId { get; set; }
        public string? DistrictName { get; set; }
        public bool IsActive { get; set; } 
        public int DivisionId { get; set; }
    }
}
