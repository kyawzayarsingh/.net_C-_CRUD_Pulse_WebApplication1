using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Data;
using WebApplication1.Interface;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Info infos)
        {
            return RedirectToAction("index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            using (TravelTourDBContext _context = new TravelTourDBContext())
            {

                return View(_context.TBLImages.ToList());
            }
        }

        [HttpPost]
        public ActionResult Contact(HttpPostedFileBase file)
        {
            string path = Server.MapPath("~/App_Data/File"); // you need to create the folder first
            //string fileName = file.FileName; // sometimes get name
            //if you want the exact file name
            string fileName = Path.GetFileName(file.FileName);

            string fullPath = Path.Combine(path, fileName);

            file.SaveAs(fullPath);
            return View();
        }

        public ActionResult CreateImage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateImage(TBLImage tBLImage)
        {
            string fileName = Path.GetFileNameWithoutExtension(tBLImage.ImageFile.FileName);
            string extension = Path.GetExtension(tBLImage.ImageFile.FileName);

            fileName = fileName + DateTime.Now.ToString("yy-mm-dd") + extension;

            tBLImage.Image = "../Image/" + fileName; // you need to create the folder first // store in DB like ../
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName); // In VS, you can use both [~/ and ../]
            tBLImage.ImageFile.SaveAs(fileName);

            using (TravelTourDBContext _context = new TravelTourDBContext())
            {
                _context.TBLImages.Add(tBLImage);
                _context.SaveChanges();
            }
            ModelState.Clear();
            return View();
        }
    }
}