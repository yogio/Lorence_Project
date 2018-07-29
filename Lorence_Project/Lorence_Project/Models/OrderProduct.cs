using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lorence_Project.Models
{
    public class OrderProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderProductID { get; set; }

        [Required, ForeignKey("Orders")]
        public int OrderID { get; set; }
        [Required, ForeignKey("Products")]
        public int ProductID { get; set; }

        //Navigation Properties
        public virtual Order Orders { get; set; }
        public virtual Product Products { get; set; }
    }
}