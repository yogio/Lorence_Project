using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lorence_Project.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        //Order's ID
        public int ID { get; set; }
        //Sit number - set as a string because it might be a description of a sit "garden" and not a number
        public string SitName { get; set; }

        //Collections between:
        //Products
        //Many-To-Many
        ICollection<Drink> Drinks { get; set; }
            //The User who made the order 
            //One-To-Many
            User Users { get; set; }
    }
}