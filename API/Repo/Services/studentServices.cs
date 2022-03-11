using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.API.Repo.Contract;
using First.API.Models;
using First.DATABASE;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

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
            //_conn.students.FromSqlRaw<Student>("usp_AddStudent @studentname ,@gender ,@studentclass ,@studentaddress ,@mobilenumber",
            //_conn.Database.ExecuteSqlRaw("usp_AddStudent @studentName,@gender,@studentClass,@studentAddress,@mobileNumber", parameters: new[] { model.studentName, model.gender, model.studentClass, model.studentAddress, model.mobileNumber } );
            //_conn.Database.ExecuteSqlRaw("usp_AddStudent 'MUkesh','MALE','BCA','BHAJANPURA','6532178'");
            _conn.Database.ExecuteSqlRaw("usp_AddStudent {0},{1},{2},{3},{4} ", model.studentName, model.gender, model.studentClass, model.studentAddress, model.mobileNumber);
            //_conn.Database.ExecuteSqlRaw("usp_AddStudent '"+ model.studentName +"' , '"+ model.gender+"', '"+model.studentClass+ "','"+ model.studentAddress+"','"+ model.mobileNumber+"' "  );
            //_conn.Database.ExecuteSqlCommand(); This command is used in EF 2.0 framework
            return model;

        }

        public bool DeleteStudent(int id)
        {
            if (id!= 0)
            {
                _conn.Database.ExecuteSqlRaw("EXEC usp_DeleteStudent {0}", id);
                return true;
            }
            else
                return false;
        }

        //public Student GetStudentById(int id)
        ////{

        ////    return
        ////}

        public List<Student> GetStudents()
        {
            var student = _conn.students.FromSqlRaw<Student>("ups_StudentDetails").ToList();
            return student;
        }

        public Student UpdateStudent(Student model )
        {
           //var getDataById = _conn.students.FromSqlRaw("usp_UpdateDetails {0},{1},{2},{3},{4},{5}", model.studentId, model.studentName, model.gender, model.studentClass, model.studentAddress, model.mobileNumber).FirstOrDefault();
            //var getDataById = _conn.students.FromSqlRaw("usp_GetByID {0}", model.studentId).FirstOrDefault();
            //var data = new Student()
            //{
            //    studentId = getDataById.studentId,
            //    studentName= getDataById.studentName,
            //    gender = getDataById.gender,
            //    studentClass= getDataById.studentClass,
            //    studentAddress= getDataById.studentAddress,
            //    mobileNumber =getDataById.mobileNumber
            //};
            _conn.Database.ExecuteSqlRaw("usp_UpdateStudent {0},{1},{2},{3},{4},{5}",model.studentId, model.studentName, model.gender, model.studentClass, model.studentAddress, model.mobileNumber);
            return model;

        }
    }
}
