using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lorence_Project.Models
{
    public class Drink
    {
        //ID of the product
        public int ID { get; set; }
        //The product's Name
        //setting the maximum number of characters to 255
        //setting the minimux number of character to 1
        [MaxLength(255)]
        [MinLength(1)]
        public string DrinkName { get; set; }
        //Collection Many-To-Many
        //the virtual if for later, possible "lazy loading".
        public virtual ICollection<Order> Orders { get; set; }

    }
}