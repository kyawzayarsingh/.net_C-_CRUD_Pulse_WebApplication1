using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Address
    {
        [Required, Key]
        public int HomeNo { get; set; }

        [Required]
        public string AddressCode { get; set; }

        [Required]
        public long PhoneNo { get; set; }
    }
}