using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;
using static WebApplication1.Enums.Enums;
using System.Data;
using Newtonsoft.Json;
using System.IO;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        TravelTourDBContext _context = new TravelTourDBContext();


        // GET: Student
        public ActionResult Index()
        {
            StudentModel studentModel = new StudentModel()
            {
                DateOfBirth = DateTime.Now
            };

           var publicQuestionLevel = from PublishQuestionLevel d in Enum.GetValues(typeof(PublishQuestionLevel))
                                select new { ID = (int)d, Name = d.ToString() };
            ViewBag.QuestionTypes = new SelectList(publicQuestionLevel, "ID", "Name");
            return View(studentModel);
        }

        public ActionResult DropDownListIndex()
        {
            var classList = _context.tblClasses.ToList();
            ViewBag.classList = new SelectList(classList, "ClassId", "ClassName");

            return View();
        }

        public PartialViewResult GetStudents(int classId)
        {
            var list = _context.tblStudents.Where(x => x.ClassId == classId).ToList();
            ViewBag.studentList = new SelectList(list, "Studentid", "StudentName");


            return PartialView("_studentPartial");
        }

        public ActionResult DropDownListForMobile()
        {
            PhoneViewModel phoneViewModel = new PhoneViewModel();
            phoneViewModel.BrandList = new List<SelectListItem>();

            foreach(var item in GetMobileBrands())
            {
                var brand = new SelectListItem()
                {
                    Value = item.BrandId.ToString(),
                    Text = item.BrandName
                };

                phoneViewModel.BrandList.Add(brand);
            }
            phoneViewModel.BrandList.Insert(0, new SelectListItem() { Value = "0", Text = "Select Phone Brand" });
            return View(phoneViewModel);
        }

        [HttpPost]
        public ActionResult GetMobilePhoneByBrandId(int brandId)
        {
            var phones = GetMobilePhones().Where(x => x.BrandId == brandId).ToList();

            return Json(new { data = phones }, JsonRequestBehavior.AllowGet);
        }
        public List<Brand> GetMobileBrands()
        {
            List<Brand> brands = new List<Brand>()
            {
                new Brand() { BrandId = 1, BrandName = "IPhone"},
                new Brand() { BrandId = 2, BrandName = "Samsung"},
                new Brand() { BrandId = 3, BrandName = "Techno"},
                new Brand() { BrandId = 4, BrandName = "Motorolla"}
            };

            return brands;
        }

        public List<Phone> GetMobilePhones()
        {
            List<Phone> phones = new List<Phone>()
            {
                new Phone(){BrandId = 1, PhoneName = "IPhone X", PhoneId = 1},
                new Phone(){BrandId = 1, PhoneName = "IPhone 11 Pro", PhoneId = 2},
                new Phone(){BrandId = 1, PhoneName = "IPhone 12 Pro Max", PhoneId = 3},
                new Phone(){BrandId = 2, PhoneName = "IPhone 8s Plus", PhoneId = 4},
                new Phone(){BrandId = 2, PhoneName = "Samsung Galaxy Note 10", PhoneId = 5},
                new Phone(){BrandId = 2, PhoneName = "Samsung S10+", PhoneId = 6},
                new Phone(){BrandId = 2, PhoneName = "Samsung S21", PhoneId = 7},
                new Phone(){BrandId = 2, PhoneName = "Samsung Note 12 Pro", PhoneId = 8},
                new Phone(){BrandId = 2, PhoneName = "Samsung Z Flip", PhoneId = 9},
                new Phone(){BrandId = 3, PhoneName = "Spark 7P", PhoneId = 10},
                new Phone(){BrandId = 3, PhoneName = "Camon 17", PhoneId = 11},
                new Phone(){BrandId = 3, PhoneName = "Camon 17 Prima", PhoneId = 12},
                new Phone(){BrandId = 3, PhoneName = "Phatom X", PhoneId = 13},
                new Phone(){BrandId = 4, PhoneName = "Motorola Edge", PhoneId = 14},
                new Phone(){BrandId = 4, PhoneName = "Moto e", PhoneId = 15}
            };

            return phones;
        }
    }
}