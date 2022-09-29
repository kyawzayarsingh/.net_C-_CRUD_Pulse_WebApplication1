using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class FilterController : Controller
    {
        //used to cache data of a particular action method for a specific time
        [OutputCache(Duration = 5)]
        // GET: Filter
        public ActionResult Index()
        {
            return View();
        }
        
        //how to do Error Page in your view
        public ActionResult Index2() {
            try
            {
                throw new Exception();
            }catch (Exception)
            {
                return RedirectToAction("Index","Error");
                //when redirect to Error Controller, Index view
                //localhost::43440/Error
            }
        }

        //HandleError built in MVC
        //usage => Go to Web.config => find <system.web></system.web> => write =>
        // <customErrors mode="On"></customErrors>
        //and then create a view in sharedFolder and named ErrorPage.cshtml and come to controller and declare [HandleError]
        //In your app_start folder, if you don't have filter.config, and you must declare your handleError in Global.asax.cs
        //GlobalFilters.Filters.Add(new HandleErrorAttribute());
        [HandleError]
        public ActionResult Index3()
        {
            throw new Exception();
        }
    }
}