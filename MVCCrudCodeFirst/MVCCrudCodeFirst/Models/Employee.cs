using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCrudCodeFirst.Models
{
    public class Employee
    {
        public Employee()
        {

        }

        //if you delcare Id, you don't need to give primary key => [Key], it already set Primary key
        //if you declare userId,employeeId except Id, so you need to set primary key like this : [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required!")]
        [Display(Name = "Your Name :")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is Required!")]
        [Display(Name= "Your Email :")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mobile is Required!")]
        [Display(Name = "Your Mobile No :")]
        [RegularExpression(@"^[0-9]{11}",ErrorMessage = "Invalid Mobile Number!")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Age is Required!")]
        [Display(Name= "Your Age :")]
        [Range(20,60, ErrorMessage = "Age must be between 20 and 60")]
        public int Age { get; set; }
    }
}