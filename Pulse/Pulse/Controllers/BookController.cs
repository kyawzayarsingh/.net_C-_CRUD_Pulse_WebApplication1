using Pulse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pulse.Controllers
{
    [RoutePrefix("books")]
    public class BookController : Controller
    {
        [Route("")]
        // GET: Book
        public ActionResult GetAllBooks()
        {
            var books = GetBook();

            return View(books);
        }

        //if we have same action, it doesn't works
        //if we have same route, it also not work, but we can defined in another way
        //just look at here from below GetBookById
        //we can also set the min of id: for example localhost:43440/books/123
        // localhost:43440/books/123=> if we want id min 3, we can use [Route("{id:int:min(3)}")]
        //min, max, length, etc..
        [Route("{id:int}")]
        public ActionResult GetBookById(int id)
        {
            var book = GetBook().FirstOrDefault(x => x.Id == id);
            return View(book);
        }

        [Route("{id}")]
        public string MyString(string id)
        {
            return id;
        }

        [Route("{id}/address")]
        public ActionResult GetBookAddress(int id)
        {
            var book = GetBook().Where(x=> x.Id == id).Select(x=>x.Address).FirstOrDefault();
            return View(book);
        }

        //we have already declare RoutePrefix from the above, so whatever we give routes, it always goes with
        // => books/id (or) books/id/address 
        //so if we don't want to use routeprefix or want to override and call like this localhost:40440/about-us
        //tips: we can use one or more Route for one Action Method 
        // but we can't use one Route for multiple action method
        [Route("~/about-us")]
        [Route("/aboutus")]
        public string AboutUs()
        {
            return "Hello This is the routes direct calling";
        }
        private List<Book> GetBook()
        {
            List<Book> books = new List<Book>()
            {
                new Book(){
                    Id = 1,
                    Title = "Sandra",
                    Author = "Servi",
                    Price = 300,
                    Address = new Address()
                    {
                        HomeNo = 1,
                        AddressCode = "Chawala",
                        PhoneNo = 099389898339
                    }

                },
                new Book(){
                    Id = 2,
                    Title = "Lawaii",
                    Author = "Linda",
                    Price = 3300,
                    Address = new Address()
                    {
                        HomeNo = 2,
                        AddressCode = "Handta",
                        PhoneNo = 093332898339
                    }

                },
                new Book(){
                    Id = 3,
                    Title = "Marvel",
                    Author = "Cristin",
                    Price = 3230,
                    Address = new Address()
                    {
                        HomeNo = 3,
                        AddressCode = "Martari",
                        PhoneNo = 09458777884
                    }

                },
                new Book(){
                    Id = 4,
                    Title = "DC",
                    Author = "Harvy",
                    Price = 700,
                    Address = new Address()
                    {
                        HomeNo = 4,
                        AddressCode = "Jinda",
                        PhoneNo = 09658658778
                    }

                }
            };

            return books;
        }
    }
}