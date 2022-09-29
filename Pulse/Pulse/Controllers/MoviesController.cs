using Pulse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pulse.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var result = new Movies { Name = "Avatar" };

            List<Movies> moviesList = new List<Movies>()
            {
                new Movies(){Id=1, Name ="kyaw"},
                new Movies(){Id=2, Name ="Mg"},
                new Movies(){Id=3, Name ="Tun"},
                new Movies(){Id=4, Name ="Wai"}
            };

            ViewBag.myMovieList = moviesList;

            ViewBag.mymovie = result.Name;

            ViewBag.myList = new List<string>() { "John", "Smith", "CardiB", "Richard" };

            ViewData["movies"] = result;

            ViewData["smovie"] = result.Name;

            ViewData["movieDataList"] = new List<string>() { "John Wick", "Spiderman", "Batman", "Superman" };

            TempData["movieName"] = result.Name;

            return View(result);
        }

        public ActionResult Index()
        {
            //return View();
            //return Content("This is a content");
            //return HttpNotFound();
            //return EmptyResult();//with emply blank page

            return RedirectToAction("Index", "Home", new { Page = 1 });
        }

        //Go to RouteConfig, check there is a routeMap and the url : ----
        //this is default and in RouteConfig, id is optional, so you can test: https://localhost:44344/Movies/edit/1
        public ActionResult Edit(int id)
        {
            return Content("Id: " + id);
        }

        //you can test in your browser like this : https://localhost:44344/Movies/Test?movieId=1
        public ActionResult Test(int movieId)
        {
            return Content("MovieId: " + movieId);
        }

        //Movies/TwoParams?PageIndex=111&sortBy=Diana
        //Movies/TwoParams => PageIndex=100, sortBy=name
        public ActionResult TwoParams(int? PageIndex, string sortBy)
        {
            if(!PageIndex.HasValue) {
                PageIndex = 100;
            }

            if (string.IsNullOrWhiteSpace(sortBy)) {
                sortBy = "name";
            }

            return Content(string.Format("PageIndex{0}&sortBy{1}",PageIndex, sortBy));
        }

        //give Custom Route in RouteConfig, route=> movies/released/2022/04
        //test in Browser => movies/ByReleaseDate?year=2022&month=04
        [Route("movies/released/{year}/{month:regex(\\d{3}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year+"/"+month);
        }

        public ActionResult TempDataOne()
        {
            TempData["myKey"] = "Data from TempDataOne";
            return View();
        }

        public ActionResult TempDataTwo()
        {
            //ViewBag.myKey = TempData["myKey"];
            //TempData.Keep();

            //If you use peek() method, you don't need to write two line code
            //peek() is used to get the data and save for the next call
            //peek() = Get Data from TempData() + keep()
            ViewBag.myKey = TempData.Peek("myKey");
            return View();
        }

        public ActionResult TempDataThree()
        {
            //you can get tempData, and data will keep() for the next call but you can't get
            //the data because of Session.Abandon()
            Session.Abandon();

            ViewBag.mykey = TempData["myKey"];
            TempData.Keep("myKey");// same with TempData.keep();
            return View();
        }

        public ActionResult TempDataFour()
        {
            ViewBag.myKey = TempData["myKey"];

            return View();
        }
    }
}