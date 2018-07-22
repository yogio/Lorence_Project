using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lorence_Project.Models
{
    public class User
    {
        //enum for the kinds of users the site will have
        public enum UserKind {Administrator = 1, Client = 2, Employee = 3};

        //for testing, we define each entity's ID
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        //Primary Key
        public int UserID { get; set; }
        //user's kind : Administrator/Client/Worker
        public UserKind userKind { get; set; }
        //User Name
        public string UserName { get; set; }
        //User Password
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //This user will have "View" credentials 
        //to complete once we have the rest of the site's logic

        //Collection to many Orders
        //Many-To-One
        public virtual ICollection<OrderSit> OrderSits { get; set; }

    }
}