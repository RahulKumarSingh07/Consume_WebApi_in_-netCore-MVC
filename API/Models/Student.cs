using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace First.API.Models
{
    public class Student
    {
        [Key]
        public int studentId { get; set; }
        [Required]
        public string studentName { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public string studentClass { get; set; }
        [Required]
        public string studentAddress { get; set; }
        [Required]
        public string mobileNumber { get; set; }


    }
}
