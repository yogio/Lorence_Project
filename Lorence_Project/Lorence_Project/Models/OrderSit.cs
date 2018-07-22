using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lorence_Project.Models
{
    public class OrderSit
    {

        //for testing, we define the DataBase ID ourselves.
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        //Order's ID
        public int OrderSitID { get; set; }
        //Sit number - set as a string because it might be a description of a sit "garden" and not a number
        public string SitName { get; set; }

        //The date the order was made
        public DateTime date { get; set; }

        //a booling that indecates if the client arrived for his order
        //it is nullable because it will either be a true of false until the date of the order actually arrived
        public bool? arrived { get; set; }

        public bool? confirmedByAdmin { get; set; }

        //Collections between:
        //Products and Users
        //Many-To-Many
        public virtual ICollection<Product> Products { get; set; }
        //The User who made the order 
        //One-To-Many
        User Users { get; set; }
    }
}