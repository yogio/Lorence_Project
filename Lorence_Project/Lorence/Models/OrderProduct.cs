using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lorence.Models
{
    public class OrderProduct
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Order's Product ID")]
        public int OrderProductID { get; set; }
        [Required]
        [ForeignKey("Product")]
        [Display(Name = "Product's ID")]
        public int ProductID {get;set;}
        [Required]
        [ForeignKey("Order")]
        [Display(Name = "Product's ID")]
        public int OrderID { get; set; }

        //Navigation Properties
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }

    }
}