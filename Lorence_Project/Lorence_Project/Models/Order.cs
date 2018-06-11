using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lorence_Project.Models
{
    public class Order
    {
        //Order's ID
        public int ID { get; set; }
        
        //Collections between:
            //Sits
            //Many-To-Many
            ICollection<Sit> Sits { get; set; }
            //Products
            //Many-To-Many
            ICollection<Drink> Drinks { get; set; }
            //The User who made the order 
            //One-To-Many

            User Users { get; set; }
    }
}