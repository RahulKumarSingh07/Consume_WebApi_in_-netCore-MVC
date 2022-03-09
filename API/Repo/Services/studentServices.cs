using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.API.Repo.Contract;
using First.API.Models;
using First.DATABASE;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace First.API.Repo.Services
{
    public class studentServices : IStudent
    {
        private readonly Databasefile _conn;
        public studentServices(Databasefile conn)
        {
            _conn = conn;
        }
        public Student CreateStudent(Student model)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public Student GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetStudents()
        {

            var student = _conn.students.FromSqlRaw<Student>("usp_StudentCrud").ToList();   
            return student;
        }

        public Student UpdateStudent(Student model)
        {
            throw new NotImplementedException();
        }
    }
}
