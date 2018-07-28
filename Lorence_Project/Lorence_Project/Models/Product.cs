using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lorence_Project.Models
{
    public enum ProductKind { Drink = 1, Food = 2}
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int ProductID { get; set; }
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Display(Name = "Product Kind")]
        public ProductKind productKind { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }

        //Navigation Properties
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}