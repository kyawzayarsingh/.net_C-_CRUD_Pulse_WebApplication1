using MVCCrudCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCrudCodeFirst.Controllers
{
    public class PublisherController : Controller
    {
        private readonly CrudDbContext _context;
        // GET: Publisher

        public PublisherController(CrudDbContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            //IList<PublisherModel> publisherList = new List<PublisherModel>();
            var query = (from publisher in _context.PublisherModels
                        select publisher).ToList();
            //foreach (var publisher in query)
            //{
            //    publisherList.Add(new PublisherModel()
            //    {
            //        Id = publisher.Id,
            //        Name = publisher.Name,
            //        Year = publisher.Year,
            //    });
            //}
            return View(query);
        }
    }
}