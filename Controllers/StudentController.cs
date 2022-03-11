using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.API.Repo.Contract;
using First.API.Models;
using Newtonsoft.Json;

namespace First.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _student;
        public StudentController(IStudent student)
        {
            _student = student;
        }

        [Route("GetStudents")]
        [HttpGet]
        public IActionResult GetStudents()
        {
            var studentData = _student.GetStudents();
            return Ok(studentData);
        }
        [HttpPost]
        [Route("CreateStudent")]
       
        public IActionResult CreateStudent(Student model)
        {
          var response = _student.CreateStudent(model);
            return Ok(response);
        }
        [HttpDelete]
        [Route("DeleteStudent")]
        public IActionResult DeleteStudent(int id)
        {
            var response = _student.DeleteStudent(id);
            return Ok(response);
        }
        //[HttpGet]
        //[Route("GetStudentById")]
        //public IActionResult GetStudentById(int id)
        //{
        //    var response = _student.GetStudentById(id);
        //    return Ok(response);
        //}
        [HttpPut]
        [Route("UpdateStudent")]
        public IActionResult UpdateStudent(Student model)
        {
            var response = _student.UpdateStudent(model);
            return Ok(response);
        }

    }
    
}
