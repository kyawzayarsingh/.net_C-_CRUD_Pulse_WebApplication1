using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    [NotMapped]
    public class Brand
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
    }
}