using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoonStar.Models
{
    public class Prod
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "price")]
        public decimal UnitPrice { get; set; }
        [Required]
        [Display(Name = "name")]
        public string ProductName { get; set; }

        public virtual ICollection<InvProd> invprods { get; set; }
    }
}