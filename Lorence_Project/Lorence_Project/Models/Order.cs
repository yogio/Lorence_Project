using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        //the name \ description of the sit.
        //shouldn't be required more than 64 characters to describe the sit ("sit 1", "bar 2")
        [MaxLength(64)]
        //Required, there's no order without the sit the order was made for
        [Required]
        [Display(Name = "Sit number or description")]

        public string Sit { get; set; }
        //Required, there's no order without a user that made the order.
        [Required]
        //UserID holds the ID of the ONE (One user To Many Orders) user who made this order.
        [ForeignKey("Users")]
        public int UserID { get; set; }
        //[Column(TypeName = "datetime2")]
        //[Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //The DateTime that the order was created, will be used to make sure a user
        //can't make an order too far in advanced.
        //The DateTime doesn't includes the time of day the order was made.
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date), Display(Name = "Date Created")]
        [Column(TypeName = "datetime2")]
        [Required]
        public DateTime DateCreated { get; set; } = DateTime.Now;
        //The DateTime that the order wants to save in advanced.
        //The DateTime includes the hour the client wants to order.
        //Required because the client needs to specificly mention when he wants to make the order
        [Required]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date), Display(Name = "Date Order")]
        public DateTime Date { get; set; }
        [Required]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time), Display(Name = "Time Order")]
        public DateTime Time { get; set; }
        //We save if the client actually arrived or not for his order, we can statisticlly analyse
        //for future reference.
        //Is nullable until the client actually arrived or didn't arrive for his order
        public bool? Arrived { get; set; }
        //We save if the Admin approves this client's order request.
        //Is nullable until the Admin decides.\
        public bool? Approved { get; set; }

        //Navigation propeties
        public virtual User Users { get; set; }

    }
}