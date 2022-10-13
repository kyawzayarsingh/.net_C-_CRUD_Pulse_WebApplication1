using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class tblClass
    {
        [Key]
        public int ClassId { get; set; }

        public string ClassName { get; set; }
    }
}