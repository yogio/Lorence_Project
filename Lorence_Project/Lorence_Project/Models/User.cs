using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lorence_Project.Models
{
    public class User
    {
        //Primary Key
        public int ID { get; set; }
        //User Name
        public string Name { get; set; }
        //User Password
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //This user will have "View" credentials 
        //to complete once we have the rest of the site's logic

        //Collection to many Orders
        //Many-To-One
        ICollection<Order> Orders { get; set; }

    }
}