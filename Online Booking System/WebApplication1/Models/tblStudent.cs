using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class tblStudent
    {
        [Key]
        public int StudentId { get; set; }

        public string StudentName { get; set; }

        [ForeignKey("Class")]
        public int ClassId { get; set; }
        public virtual tblClass Class {get;set;}
    }
}