using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    public class PhoneViewModel
    {
        public List<Brand> Brands { get; set; }
        public List<Phone> Phones { get; set; }

        [Display(Name = "Moblie Brand")]
        public string MobileBrand { get; set; }

        [Display(Name = "Moblie Phone")]
        public string MobilePhone { get; set; }
        public List<SelectListItem> BrandList { get; set; }
    }
}