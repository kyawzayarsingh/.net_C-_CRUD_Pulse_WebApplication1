using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Package
    {
        public int Id { get; set; }

        [ForeignKey("Destination")]
        public int Destination_Id { get; set; }
        public virtual Destination Destination { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, StringLength(500)]
        public string Description { get; set; }
        public double Price { get; set; }

        [ForeignKey("User")]
        public int Created_User_Id { get; set; }
        public virtual User User { get; set; }
    }
}