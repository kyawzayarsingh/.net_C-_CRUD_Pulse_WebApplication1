using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class BaseModel
    {
       public BaseModel()
        {
            LastUpdate = DateTime.UtcNow;
            LastUpdatedBy = HttpContext.Current.User.Identity.Name;
        }
        [Column(TypeName = "datetime2")]
        [ScaffoldColumn(false)]
        public DateTime LastUpdate { get; set; }

        [StringLength(50)]
        [ScaffoldColumn(false)]
        public string LastUpdatedBy { get; set; }

    }
}