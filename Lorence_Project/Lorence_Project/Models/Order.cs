using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lorence_Project.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int OrderID { get; set; }
        [Required,ForeignKey("SitOrder")]
        [Display(Name = "Sit ID")]
        public int SitID { get; set; }
        [Display(Name = "Client Arrived")]
        public bool? Arrived { get; set; }
        [Display(Name = "Order's Approval")]
        public bool? Approved { get; set; }

        [Required, ForeignKey("AspNetUsers")]
        [Display(Name = "User's ID")]
        public string UserID { get; set; }

        //When trying to get the DB to create the Date there's an error, need to go over later.
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Date Order Created")]
        [DataType(DataType.Date)]
        
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateCreated { get; set; } = DateTime.Now;
        [Required, Display(Name = "Date and Time of the order")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        //Navigation Properties
        public virtual SitOrder SitOrder { get; set; }
        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual ICollection<OrderProduct> orderProducts { get; set; }

  
    }
}