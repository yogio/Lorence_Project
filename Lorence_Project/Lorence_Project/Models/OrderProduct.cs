﻿using System;
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

        [Required, ForeignKey("Order")]
        public int OrderID { get; set; }

        //Navigation Properties
        public virtual Order Order { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}