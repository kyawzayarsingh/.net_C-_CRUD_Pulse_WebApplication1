using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pulse.Models;

namespace Pulse.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index(string name)
        {
            var data = GetEmployee();
            return View(data);
        }

        private Employee GetEmployee()
        {
            Employee employee = new Employee()
            {
                Id = 1,
                Name = "Kyaw Zayar Win",
                Address = "Lokhand Waala"
            };

            return employee;
        }


        public ActionResult InlineHtmlHelper()
        {
            return View(); 
        }

        public ActionResult About(string name)
        {
            return View();
        }

        public ActionResult StronglyHtmlHelper()
        {
            Employee emp = new Employee()
            {
                Name = "Raj",
                Address = "Tharyawady"
            };
            return View(emp);
        }

        [HttpPost]
        public ActionResult StronglyHtmlHelper(Employee employee)
        {
            return View();
        }
        
        public ActionResult TemplatedHtmlHelper()
        {
            Employee emp = new Employee()
            {
                Id = 1,
                Name = "Kyaw Zayar Win",
                DateOfBirth = DateTime.Now,
                Password = "rajsingh123",
                Address = "Jila"
            };
            return View(emp);
        }

        [HttpPost]
        public ActionResult TemplatedHtmlHelper(Employee employee)
        {
            return View();
        }
    }
}