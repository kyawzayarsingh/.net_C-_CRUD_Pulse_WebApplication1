using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Pulse.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "My Name")]
        public string Name { get; set; }

        [Required, Display(Name = "Full Address")]
        public string Address { get; set; }

        [Display(Name = "Date Of Birth")]
        //[DataType(DataType.Date, ErrorMessage = "Date only")]
        public DateTime DateOfBirth { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}