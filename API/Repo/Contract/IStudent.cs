using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using First.API.Models;

namespace First.API.Repo.Contract
{
  public interface IStudent
    {
        List<Student> GetStudents();
        Student CreateStudent(Student model);
        bool  DeleteEmployee(int id);
        Student UpdateStudent(Student model);
        Student GetEmployeeById(int id);
    }
}
