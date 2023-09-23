using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoonStar.Models
{
    public class Inv
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "name")]
        public string inname { get; set; }

        public virtual ICollection<InvProd> invprods { get; set; }

    }
}