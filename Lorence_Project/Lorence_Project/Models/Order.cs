using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lorence_Project.Models
{
    public enum SitKind { Table = 1, Bar = 2}
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int OrderID { get; set; }
        [Required]
        public string Sit { get; set; }
        [Required]
        public SitKind sitKind { get; set; }
        public bool? Arrived { get; set; }
        public bool? Approved { get; set; }
        [ForeignKey("AspNetUsers")]
        [Display(Name = "User's ID")]
        public ApplicationUser UserID { get; set; }
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="Date Order Created")]
        public DateTime TimeCreated { get; set; }
        [Required, Display(Name = "Date of the order")]
        public DateTime Date { get; set; }
  
        //Navigation Properties
        public ApplicationUser User { get; set; }
        public OrderProduct orderProduct { get; set; }


    }
}