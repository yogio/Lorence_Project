using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lorence_Project.Models
{
    //There are 2 kinds of products: Drink ("1") and Food ("2")
    public enum ProductKind { Drink = 1, Food = 2 };

    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        //ID of the product
        [DisplayName("ID Number")]
        [Key]
        public int ProductID { get; set; }
        //The product's Name
        [DisplayName("Kind of product")]
        public ProductKind productKind { get; set; }
        //The name of the product
        [DisplayName("Product's ame")]
        public string productName { get; set; }
        //The Description of the product
        [DisplayName("Description")]
        public string description { get; set; }
        //Collection Many-To-Many
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }

    }
}