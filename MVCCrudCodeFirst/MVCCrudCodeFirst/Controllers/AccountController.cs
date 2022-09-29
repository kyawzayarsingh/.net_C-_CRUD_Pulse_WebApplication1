using System.Linq;
using System.Web.Mvc;
using MVCCrudCodeFirst.Models;
using System.Web.Security;

namespace MVCCrudCodeFirst.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            using(var context = new CrudDbContext())
            {
                bool isValid = context.Users.Any(x => x.UserName == user.UserName && x.Password == user.Password);
                if(isValid)
                {
                    //false means I don't want to save on browser
                    FormsAuthentication.SetAuthCookie(user.UserName, true);
                    return RedirectToAction("Index", "Employees");
                }
                ModelState.AddModelError("", "Invalid UserName and Password");
                ModelState.Clear(); // after going to view, UserName and Password will be clear
            }
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User user)
        {
            using(var context = new CrudDbContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}