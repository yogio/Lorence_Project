using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lorence_Project.Models
{
    public enum SitKind { Table = 1, Bar = 2 }

    public class SitOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SitOrderID { get; set;}
        public string SitLocation { get; set; }

        public SitKind sitKind { get; set; }

        //Navegation Properties
        public virtual ICollection<Order> Orders { get; set; }
    }
}