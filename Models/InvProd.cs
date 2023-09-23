using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoonStar.Models
{
    public class InvProd
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Customer Name")]
        public string CustName { get; set; }


        [Required]
        [Display(Name = "Pro Name")]
        public int ProductId { get; set; }

        [Required]
        [Display(Name = "Inv Name")]
        public int InvId { get; set; }
      
        public virtual Inv invoice { get; set; }
        public virtual Prod product { get; set; }



    }
}