using System.ComponentModel.DataAnnotations;

namespace MVCCrudCodeFirst.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "username is required!")]
        [Display(Name = "User Name :")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "password is required!")]
        [Display(Name = "Password :")]
        public string Password { get; set; }
    }
}