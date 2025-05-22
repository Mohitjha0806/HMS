using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Entities.Models
{
    public class HospitalTypeModel
    {
        [Key]
        public int HospitalTypeID { get; set; }
        public required string HospitalTypeName { get; set; }
    }
}
