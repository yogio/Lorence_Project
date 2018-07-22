using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lorence_Project.Models
{
    //There are 2 kinds of products: Drink ("1" for the tables) and Food ("2" for the tables)
    public enum ProductKind { Drink = 1, Food = 2 };

    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        //ID of the product
        public int ProductID { get; set; }
        //The product's Name
        public ProductKind productKind { get; set; }
        //The name of the product
        public string ProductName { get; set; }
        //The Description of the product
        public string Description { get; set; }
        //Collection Many-To-Many
        public virtual ICollection<OrderSit> OrderSits { get; set; }

    }
}