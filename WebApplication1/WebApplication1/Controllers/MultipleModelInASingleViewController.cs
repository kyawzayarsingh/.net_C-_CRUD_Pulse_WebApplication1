using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class MultipleModelInASingleViewController : Controller
    {
        // GET: MultipleModelInASingleView
        public ActionResult Index()
        {
            var employees = GetEmployees();
            var students = GetStudents();

            //using viewModels, create object and assign to it
            EmployeeStudentViewModel model = new EmployeeStudentViewModel();
            model.Employees = employees;
            model.Students = students;

            return View(model);
        }

        //using dynamic, so you don't want to create ViewModels
        // you can call in here directly
        public ActionResult DynamicModel()
        {
            var employees = GetEmployees();
            var students = GetStudents();

            dynamic model = new ExpandoObject();
            //you can set model.anyname, call in View with that name
            model.empList = employees;
            model.stuList = students;

            return View(model);
        }

        //using Tuple
        public ActionResult TupleModel()
        {
            var employees = GetEmployees();
            var students = GetStudents();

            //in Tuple<Type, passData>, just go to definition, you will get it
            var model = new Tuple<List<Employee>, List<Student>,string>(employees,students,"Kyaw");
            return View(model);
        }

        private List<Employee> GetEmployees()
        {
            List<Employee> employee = new List<Employee>()
            {
                new Employee() { Id = 1, Name = "kyaw"}, 
                new Employee() { Id = 2, Name = "Mg"}, 
                new Employee() { Id = 3, Name = "Wai"}, 
                new Employee() { Id = 4, Name = "Myint"}
            };

            return employee;
        }

        private List<Student> GetStudents()
        {
            List<Student> employee = new List<Student>()
            {
                new Student() {StudentId = 1, StudentName = "Skyaw"},
                new Student() {StudentId = 2, StudentName = "SMg"},
                new Student() {StudentId = 3, StudentName = "SWai"},
                new Student() {StudentId = 4, StudentName = "SMyint"}
            };

            return employee;
        }
    }
}