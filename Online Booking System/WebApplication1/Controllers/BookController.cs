using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [RoutePrefix("Books")]
    public class BookController : Controller
    {
        private readonly TravelTourDBContext _context = null;

        public BookController()
        {
            _context = new TravelTourDBContext();
        }

        [Route("")]
        // GET: Book
        public ActionResult GetAllBooks()
        {
            var books = GetBooks();
            return View(books);
        }


        [Route("{id:int}")]
        public ActionResult GetBookById(int id)
        {
            var book = GetBooks().FirstOrDefault(x => x.Id == id);
            return View(book);
        }

        [Route("{id}/address")]
        public JsonResult GetAddressById (int id)
        {
            var address = GetBooks().Where(x => x.Id == id).Select(x => x.Address).FirstOrDefault();
            var json = JsonConvert.SerializeObject(address);

            return Json(json, JsonRequestBehavior.AllowGet);
        }

        private List<Book> GetBooks()
        {
            List<Book> books = new List<Book>()
            {
                new Book()
                {
                     Id = 1,
                    Title = "Sandra",
                    Author = "Servi",
                    Price = "300",
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
                    Price = "3300",
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
                    Price = "3000",
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
                    Price = "700",
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