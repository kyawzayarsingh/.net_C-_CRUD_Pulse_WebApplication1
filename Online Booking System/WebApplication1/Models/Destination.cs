using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Destination
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, StringLength(500)]
        public string Description { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Division { get; set; }

        [ForeignKey("User")]
        public int Created_User_Id { get; set; }
        public virtual User User { get; set; }
    }
}