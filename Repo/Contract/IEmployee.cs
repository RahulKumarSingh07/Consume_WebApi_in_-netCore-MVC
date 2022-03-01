using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.Models;
using First.Models.ViewModel;

namespace First.Repo.Contract
{
    public interface IEmployee
    {
       // List<Employee> GetEmployees();
        Employee CreateEmployee(EmployeeViewModel model);
        List<Qualification> GetQualifications();
        bool DeleteEmployee(int id);
        Employee UpdateEmployee(EmployeeViewModel employee);
        Employee GetEmployeeById(int id);
    }
}
