using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace First.Models
{
    public class Emptype
    {
        [Key]
        [Required]
        public int Tid { get; set; }
        [Required]
        public string Types { get; set; }
    }
}
