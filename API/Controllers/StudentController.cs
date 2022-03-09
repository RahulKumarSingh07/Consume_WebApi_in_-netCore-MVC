using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.API.Repo.Contract;
using First.API.Models;
using Newtonsoft.Json;

namespace First.API.Controllers
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
        [Route("api/[controller]")]
        [HttpGet]
        public IActionResult GetStudents(Student student)
        {
            var studentData = _student.GetStudents();
            return Ok(studentData);
        }

        
    }
}
