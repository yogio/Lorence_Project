using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lorence.Models
{
    public enum ProductKind { Drink = 1, Food = 2 }
    public class Product
    {
        [Key]
        [Display(Name = "Product's ID")]
        public int ProductID { get; set; }
        [Required, Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Required, Display(Name = "Product Kind")]
        public ProductKind ProductKind { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }

        //Navigation Properties
        public virtual ICollection<OrderProduct> OrderProduct { get; set; }
    }
}