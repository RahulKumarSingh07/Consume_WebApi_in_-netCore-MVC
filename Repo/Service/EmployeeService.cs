using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.Models;
using First.Models.ViewModel;
using First.Repo.Contract;
using First.DATABASE;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace First.Repo.Service
{
   
    public class EmployeeService : IEmployee
    {
        private readonly Databasefile _Conn;
        public EmployeeService(Databasefile Conn)
        {
            this._Conn = Conn;
        }

        //public List<Employee> GetEmployees()
        //{
        //    return _Conn.Employees.Where(e => e.IsActive == true).ToList();
        //}

        public Employee CreateEmployee(EmployeeViewModel model)
        {
            var bind = _Conn.Qualifications.SingleOrDefault(x=>x.Id==model.QualificationId);
            var employee = new Employee {
                Name = model.Name,
                Gender = model.Gender,
                Qf = bind,
                Address = model.Address,
                City = model.City,
                IsActive = model.IsActive
            };
            _Conn.Employees.Add(employee);
            _Conn.SaveChanges();
            return employee;
        }

        public List<Qualification> GetQualifications()
        {
            return _Conn.Qualifications.ToList();
        }

        public bool DeleteEmployee(int id)
        {
            var emp = _Conn.Employees.SingleOrDefault(x=> x.Id==id);
            if (emp != null)
            {
                _Conn.Employees.Remove(emp);
                _Conn.SaveChanges();
                return true;
            }
            return false;
        }

        public Employee UpdateEmployee(EmployeeViewModel employee)
        {
            var bind = _Conn.Qualifications.SingleOrDefault(e => e.Id == employee.QualificationId);
            var emp2 = _Conn.Employees.SingleOrDefault(e => e.Id == employee.Id);
            emp2.Name = employee.Name;
            emp2.Gender = employee.Gender;
            emp2.Qf = bind;
            emp2.Address = employee.Address;
            emp2.City = employee.City;
            emp2.IsActive = employee.IsActive;
            _Conn.Employees.Update(emp2);
            _Conn.SaveChanges();
            return emp2;
        }

        public Employee GetEmployeeById(int id)
        {
            return _Conn.Employees.SingleOrDefault(e => e.Id == id);
        }
    }
}
