using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.DATABASE;
using First.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using First.Models.ViewModel;

namespace First.Controllers
{
    public class NewEmployee : Controller
    {
        private readonly Databasefile _context;
        public NewEmployee(Databasefile context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var getemp = (from E in _context.NewEmployees
                          join D in _context.Designations_Col on E.Degisnation.Did equals D.Did
                          join Ep in _context.Emptypes on E.Emptype.Tid equals Ep.Tid
                          select new CommonModel
                          {
                              Empid = E.Empid,
                              Name = E.Name,
                              Degisnation = D.Designations,
                              Salary = E.salary,
                              Bonus = E.Bonus,
                              Emptype = Ep.Types,
                              City = E.City,
                              State = E.State,
                              Pincode = E.Pincode,
                              Website = E.Website,
                              Address = E.Address
                          }).ToList();
            return View(getemp);
        }
        public IActionResult Create()
        {
            var dgdata = (from d in _context.Designations_Col
                          select new SelectListItem()
                          {
                              Text = d.Designations,
                              Value = d.Did.ToString()
                          }).ToList();
            dgdata.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = string.Empty
            });
            var Etydata = (from E in _context.Emptypes
                           select new SelectListItem()
                           {
                               Text = E.Types,
                               Value = E.Tid.ToString()
                           }).ToList();
            Etydata.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = string.Empty
            });
            ViewBag.ListofDegis = dgdata;
            ViewBag.Listoftype = Etydata;
            return View();
        }
        [HttpPost]
        public IActionResult Create(CommonModel model)
        {
            var degs = _context.Designations_Col.SingleOrDefault(x => x.Did == model.Did);
            var emtype = _context.Emptypes.SingleOrDefault(x => x.Tid == model.Etypeid);
            var employee = new EmployeeNew
            {
                Name = model.Name,
                Degisnation = degs,
                salary = model.Salary,
                Bonus = model.Bonus,
                Emptype = emtype,
                Address = model.Address,
                City = model.City,
                State = model.State,
                Pincode = model.Pincode,
                Website = model.Website
            };
            _context.NewEmployees.Add(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var dgdata = (from d in _context.Designations_Col
                          select new SelectListItem()
                          {
                              Text = d.Designations,
                              Value = d.Did.ToString()
                          }).ToList();
            dgdata.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = string.Empty
            });
            var Etydata = (from E in _context.Emptypes
                           select new SelectListItem()
                           {
                               Text = E.Types,
                               Value = E.Tid.ToString()
                           }).ToList();
            Etydata.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = string.Empty
            });
            ViewBag.ListofDegis = dgdata;
            ViewBag.Listoftype = Etydata;
            //var dgs = _context.Designations_Col.SingleOrDefault(x => x.Did==);
            var emp = _context.NewEmployees.SingleOrDefault(x => x.Empid == id);
            var employee = new CommonModel();
            employee.Empid = emp.Empid;
            employee.Name = emp.Name;
            employee.Salary = emp.salary;
            //     employee.Degisnation = emp.Degisnation.Designations;
            employee.Bonus = emp.Bonus;
            //   employee.Emptype = emp.Emptype.Types;
            employee.City = emp.City;
            employee.State = emp.State;
            employee.Pincode = emp.Pincode;
            employee.Website = emp.Website;
            employee.Address = emp.Address;
            return View(employee);
        }
        [HttpPost]
        public IActionResult Update(CommonModel employee)
        {
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                var degs = _context.Designations_Col.SingleOrDefault(x => x.Did == employee.Did);
                var emtype = _context.Emptypes.SingleOrDefault(x => x.Tid == employee.Etypeid);
                var emp2 = _context.NewEmployees.SingleOrDefault(e => e.Empid == employee.Empid);
                emp2.Name = employee.Name;
                emp2.salary = employee.Salary;
                emp2.Degisnation = degs;
                emp2.Bonus = employee.Bonus;
                emp2.Emptype = emtype;
                emp2.City = employee.City;
                emp2.State = employee.State;
                emp2.Pincode = employee.Pincode;
                emp2.Website = employee.Website;
                emp2.Address = employee.Address;
                _context.NewEmployees.Update(emp2);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public IActionResult DeleteEmp(int? id)
        {
            if (id != null)
            {
                var delemp = _context.NewEmployees.SingleOrDefault(x => x.Empid == id);
                _context.NewEmployees.Remove(delemp);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        public IActionResult viewEmp(int? id)
        {
            var getemp = (from E in _context.NewEmployees
                          join D in _context.Designations_Col on E.Degisnation.Did equals D.Did
                          join Ep in _context.Emptypes on E.Emptype.Tid equals Ep.Tid
                          select new CommonModel
                          {
                              Empid = E.Empid,
                              Name = E.Name,
                              Degisnation = D.Designations,
                              Salary = E.salary,
                              Bonus = E.Bonus,
                              Emptype = Ep.Types,
                              City = E.City,
                              State = E.State,
                              Pincode = E.Pincode,
                              Website = E.Website,
                              Address = E.Address
                          }).ToList();
            return View(getemp);
        }
     
    }
}
