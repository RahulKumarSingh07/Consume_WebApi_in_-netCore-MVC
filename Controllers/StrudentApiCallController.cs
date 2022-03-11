using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.API.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace First.Controllers
{
    public class StrudentApiCallController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Student> students = new List<Student>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44326/api/Student/GetStudents"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    students = JsonConvert.DeserializeObject<List<Student>>(apiResponse);
                }
            }
                return View(students);
        }

        //[HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student students)
        {
            Student lstudents = new Student();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(students), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:44326/api/Student/CreateStudent", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    lstudents = JsonConvert.DeserializeObject<Student>(apiResponse);
                }
            }
            return RedirectToAction("Index");

        }
    }
}
