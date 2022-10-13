using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace WebApplication1.Models
{
    public class TBLImage
    {
        public int Id { get; set; }
        
        [StringLength(255)]
        public string Title { get; set; }

        [StringLength(2000), Display(Name = "Upload Image")]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}