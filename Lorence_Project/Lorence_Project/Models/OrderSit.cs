using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lorence_Project.Models
{
    public class OrderSit
    {

        //for testing, we define the DataBase ID ourselves.
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Order ID")]
        //Order's ID
        [Key]
        public int OrderSitID { get; set; }
        [DisplayName("Sit Name")]
        //Sit number - set as a string because it might be a description of a sit "garden" and not a number
        public string SitName { get; set; }
        [DisplayName("Order made by the date")]
        //The date the order was made
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        //[Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime dateOrdered { get; set; }
        //the date the order was made for
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [DisplayName("Order for the date")]
        public DateTime orderDate { get; set; }

        [DisplayName("User ID that made the order")]
        [ForeignKey("Users")]
        [Required]
        //the foreign key that connects us to the specific user who made the order
        public int UserID { get; set; }
        [DisplayName("Arrived")]
        [DisplayFormat(NullDisplayText = "Not decided yet")]
        //a booling that indecates if the client arrived for his order
        //it is nullable because it will either be a true of false until the date of the order actually arrived
        public bool? arrived { get; set; }
        [DisplayName("Confirmed By Administrator")]
        [DisplayFormat(NullDisplayText = "Not confirmed yet")]
        public bool? confirmedByAdmin { get; set; }

        //Collections between:
        //Products and Users
        //Many-To-Many
        public virtual ICollection<Product> Products { get; set; }
        //The User who made the order 
        //One-To-Many
        public virtual ICollection<User> Users { get; set; }
    }
}