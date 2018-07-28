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
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public ProductKind productKind { get; set; }
        public string Description { get; set; }

        //Navigation Properties
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}