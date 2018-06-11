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
        //is set to have a max of 16 characters
        [MaxLength(16)]
        [Required]
        public string Name { get; set; }
        //User Password
        //setting the password to have a min of 6 characters
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        [MinLength(6)]
        [Required]
        public string Password { get; set; }

        //This user will have "View" credentials 
        //to complete once we have the rest of the site's logic

        //Collection to many Orders
        //Many-To-One
        public virtual ICollection<Order> Orders { get; set; }

    }
}