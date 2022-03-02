using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace First.Models
{
    public class State
    {
        [Key]
        public int S_Id { get; set; }

        public string StateName { get; set; }

        public Country GetCountry { get; set; }
    }
}
