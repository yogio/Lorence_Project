using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lorence_Project.Models
{
    //this table comes to make the connection between OrderSit and Products.
    //OrderSit can order Many kinds of Products and Products can relate to Many Orders of Products.
    public class OrderProduct
    {
        //OrderProduct ID
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderProductID { get; set; }
        //ProductID for a specific product created for an OrderSit
        public int productID { get; set; }
        //OrderSitID for many products
        public int OrderID { get; set; }

        //related Tables
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Order> Orders { get; set; }


    }
}