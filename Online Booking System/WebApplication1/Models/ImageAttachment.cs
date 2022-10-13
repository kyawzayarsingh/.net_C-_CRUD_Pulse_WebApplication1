using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class ImageAttachment : BaseModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [Required, StringLength(200)]
        public string FileName { get; set; }

        [Required, StringLength(5)]
        public string FileType { get; set; }

        [Required]
        public string FileBase64 { get; set; }

        [DataType("decimal(18,2)")]
        public string FileSize { get; set; }

    }
}