using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lorence.Models
{
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Order ID")]
        public int OrderID { get; set; }
        [Required]
        [ForeignKey("Sit")]
        [Display(Name = "Sit ID")]
        public int SitID { get; set; }
        public bool? Arrive { get; set; }
        public bool? Approved { get; set; }
        [ForeignKey("ApplicationUser")]
        [Display(Name = "Users ID")]
        public string UserID { get; set; }
        [DataType(DataType.Date)]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Date Order Created")]
        public DateTime DateCreated { get; set; } = DateTime.Now.Date;
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Order Date")]
        public DateTime TimeOrdered { get; set; }

        //Navigation Properties
        public virtual Sit Sit { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}