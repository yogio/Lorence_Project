using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lorence_Project.Models
{
    public class Sit
    {
        //Primary key
        public int ID { get; set; }
        //Sit number - set as a string because it might be a description of a sit "garden" and not a number
        public string SitName { get; set; }
        //Collections to Order
        //the virtual if for later, possible "lazy loading".
        public virtual ICollection<Order> Orders { get; set; }

    }
}