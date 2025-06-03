using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Entities.Models
{
    public class MstBlock
    {

        [Key]
        public int BlockId { get; set; }
        public string? BlockName { get; set; }
        public bool IsActive { get; set; }
        public int DistrictId { get; set; }
    }
}
