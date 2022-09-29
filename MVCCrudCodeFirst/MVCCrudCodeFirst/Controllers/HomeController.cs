using MVCCrudCodeFirst.interfaces;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MVCCrudCodeFirst.Controllers
{
    public class HomeController : Controller
    {
        private IEmployee _employee = null;

        public HomeController(IEmployee employee)
        {
            _employee = employee;
        }

        public ActionResult Index()
        {
            int count = _employee.GetTotalStudent();
            return View();
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

        public ActionResult Test()
        {
            var list = new List<string>() { "America", "Japan", "Singapore", "New Zealand", "Canada", "UK" };
            ViewBag.list = list;
            return View();
        }
    }
}