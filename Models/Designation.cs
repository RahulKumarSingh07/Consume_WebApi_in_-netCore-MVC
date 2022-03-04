using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace First.Models
{
    public class Designation
    {
        [Key]
        [Required]
        public int Did { get; set; }
        [Required]
        public string Designations { get; set; }
    }
}
