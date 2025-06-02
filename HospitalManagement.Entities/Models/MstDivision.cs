using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Entities.Models
{
    public class MstDivision
    {
        [Key]
        public int DivisionId { get; set; }

        [Required]
        [StringLength(50)]
        public required string DivisionName { get; set; }
        public bool IsActive { get; set; }

    }
}
