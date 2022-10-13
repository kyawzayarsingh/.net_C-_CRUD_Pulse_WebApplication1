using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Info
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, Display(Name = "Father Name")]
        public string FatherName { get; set; }
    }
}