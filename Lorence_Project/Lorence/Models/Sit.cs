using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lorence.Models
{
    public enum SitKind { Table = 1, Bar = 2 }
    public class Sit
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SitID { get; set; }
        [Required]
        public SitKind SitKind { get; set; }
        [Required]
        public string SitName { get; set; }

        //Navigation Properties
        public virtual ICollection<Order> Orders { get; set; }

    }
}