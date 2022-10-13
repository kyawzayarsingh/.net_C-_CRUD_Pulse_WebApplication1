using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class User : BaseModel
    {
        public User()
        {
            ImageAttachments = new List<ImageAttachment>();
        }
        public int Id { get; set; }

        [Required,StringLength(100)]
        public string Name { get; set; }

        [Required, StringLength(100)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name="User Profile")]
        public string Profile { get; set; }

        [Required, Display(Name = "Type [Admin - 0,User - 1]")]
        [Range(0,1, ErrorMessage = "Type must be between 0 and 1")]
        public int Type { get; set; }

        [Required, StringLength(11)]
        [RegularExpression(@"^[0-9]{11}", ErrorMessage = "Invalid Phone Number!")]
        public string Phone { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        public int Status { get; set; }
        public virtual ICollection<ImageAttachment> ImageAttachments { get; set; }

    }
}