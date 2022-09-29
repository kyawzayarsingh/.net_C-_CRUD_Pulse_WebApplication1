using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        //using paramters get data from view
        [HttpPost]
        //firstname, lastname is coming from ui, input type => name attribute
        public string PostUsingParameter(string firstname, string lastname)
        {
            return "From Parameter: " + firstname + " " + lastname;
        }

        //using requests, get data from view
        [HttpPost]
        //firstname, lastname is coming from ui, input type => name attribute
        public string PostUsingRequest()
        {
            string firstname = Request["firstname"];
            string lastname = Request["lastname"];
            return "From Request: " + firstname + " " + lastname;
        }

        //using form collection, get data from view
        [HttpPost]
        //firstname, lastname is coming from ui, input type => name attribute
        public string PostUsingFormCollection(FormCollection form)
        {
            string firstname = form["firstname"];
            string lastname = form["lastname"];
            return "From Form Collection: " + firstname + " " + lastname;
        }

        [HttpPost]
        public string PostUsingBinding(Employee emp)
        {
            return "From Form Collection: " + emp.Name + " " + emp.Email;
        }

        [HttpPost]
        public ActionResult SubmitData(Employee emp)
        {
            if(ModelState.IsValid)
            {
                return View();
            }
            return View("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult GetEmployee()
        {
            Employee emp = new Employee()
            {
                Id = 1,
                Name = "Kyaw Kyaw",
                Email = "oblivion.geomancer7@gmail.com"
            };

            var json = JsonConvert.SerializeObject(emp);

            return Json(json,JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddEmployee(Employee emp)
        {
            return Json("true", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AjaxHelper()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AjaxHelper(Employee emp)
        {
            return Json("true", JsonRequestBehavior.AllowGet);
        }

        public ActionResult AjaxList()
        {
            return View(); 
        }

        public JsonResult Countries()
        {
            List<string> countries = new List<string>()
            {
                "country - Bago",
                "country - Yangon",
                "country - Mandalay",
                "country - Sagaing",
                "country - Ayeyarwaddy",
                "country - Shan",
                "country - Mon"
            };

            var json = JsonConvert.SerializeObject(countries);
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public JsonResult States()
        {
            List<string> states = new List<string>()
            {
                "State - Bago",
                "State - Yangon",
                "State - Mandalay",
                "State - Sagaing",
                "State - Ayeyarwaddy",
                "State - Shan",
                "State - Mon"
            };

            var json = JsonConvert.SerializeObject(states);
            return Json(json,JsonRequestBehavior.AllowGet);
        }

        public JsonResult Cities()
        {
            List<string> cities = new List<string>()
            {
                "city - Bago",
                "city - Yangon",
                "city - Mandalay",
                "city - Sagaing",
                "city - Ayeyarwaddy",
                "city - Shan",
                "city - Mon"
            };

            var json = JsonConvert.SerializeObject(cities);
            return Json(json,JsonRequestBehavior.AllowGet);
        }

        public ActionResult PartialIndex()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee() { Id = 1, Name = "kyaw Win", Email = "kyaw@gmail.com"},
                new Employee() { Id = 2, Name = "kyaw Naing", Email = "Naing@gmail.com"},
                new Employee() { Id = 3, Name = "kyaw Swar", Email = "Swar@gmail.com"},
                new Employee() { Id = 4, Name = "kyaw Myint", Email = "Myint@gmail.com"},
            };

            return View(employees);
        }
    }
}