using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [ForeignKey("Package")]
        public int Package_Id { get; set; }
        public virtual Package Package { get; set; }

        [Required, Range(1,20, ErrorMessage = "Guest Number must be between 1 and 20")]
        public int Guest_No { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime Booking_Date { get; set; }

        [Required]
        public double TotalPrice { get; set; }

        [Required]
        public string Booking_Remark { get; set; }
        public int Status { get; set; }

    }
}