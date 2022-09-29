using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Employee
    {
        public int Id { get; set; } 

        [Required]
        //if you want to allow html tag in your form for the field you want to
        // you need to declare on that model field like this: [AllowHtml] and if you don't want to delcare [AllowHtml]
        // to each property of a model so you will go to the View which have that form and go their related Actions method
        // In Controller Action methods, [ValidateInput(false)]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public List<string> Programming { get; set; }

        public string LastName { get; set; }

        public List<Techs> NewProgramming { get; set; }
    }

    //well we can set in ViewModel also, Go to AOC_STMS look around there...
    public class Techs
    {
        public string Technology { get; set; }
    }
}