using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MultipleSubmitButtonController : Controller
    {
        // GET: MultipleSubmitButton
        public ActionResult Index()
        {
            return View();
        }

        //if two of the button type given name is not the same
        [HttpPost]
        public ActionResult Index(Employee emp, string create, string edit)
        {
            if(create == "Create")
            {
                //
            } else if(edit == "Edit")
            {
                //
            }
            return View();
        }

        //if two of the button type given name is same
        //[HttpPost]
        //public ActionResult Index(Employee emp, string submitData)
        //{
        //    if(submitData == "Create")
        //    {
        //        //
        //    } else if(submitData == "Edit")
        //    {
        //        //
        //    }
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Edit(Employee emp)
        //{
        //    return RedirectToAction("Index");
        //}

        //ChildActionOnly means the below partial view page cannot access from URL
        //it can access from where you can write {Html.RenderAction("")} in your any view.
        [ChildActionOnly]

        //also if you change the public to private, you cannot access from the URL and from the Code
        //short form - [NonAction] is equal to Private, if you don't write private, so you can ad [NonAction] in your public action method
        public PartialViewResult Raj()
        {
            return PartialView("_PartialRaj");
        }
    }
}