using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First.Models.ViewModel
{
    public class EmployeeViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int QualificationId { get; set; }
        public string QualificationName { get; set; }
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public int StateID { get; set; }
        public string StateName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public bool IsActive { get; set; }

    }
}
