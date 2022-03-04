using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace First.Models
{
    public class EmployeeNew
    {
        [Key]
        [Required]
        public int Empid { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Designation Degisnation { get; set; }
        [Required]
        public int salary { get; set; }
        [Required]
        public int? Bonus { get; set; }
        [Required]
        public Emptype Emptype { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public int Pincode { get; set; }
        [Required]
        public string Website { get; set; }


    }
}
