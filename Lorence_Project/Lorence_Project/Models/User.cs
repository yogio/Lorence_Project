using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lorence_Project.Models
{
    public class User
    {
        //Primary Key
        public int ID { get; set; }
        //User Name
        public string Name { get; set; }
        //User Password
        public string Password { get; set; }

        //This user will have "View" credentials 
        //to complete once we have the rest of the site's logic


    }
}