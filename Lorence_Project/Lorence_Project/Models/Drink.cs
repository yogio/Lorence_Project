using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lorence_Project.Models
{
    public class Drink
    {
        //ID of the product
        public int ID { get; set; }
        //The product's Name
        public string DrinkName { get; set; }
        //Collection Many-To-Many
        ICollection<Order> Orders { get; set; }

    }
}