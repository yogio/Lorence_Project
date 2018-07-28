using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lorence_Project.Models
{
    public class LorenceUser : IdentityUser
    {
        [Display(Name = "Arrived")]
        public bool? Arrived { get; set; }
        [Display(Name = "Approved By Admin")]
        public bool? Approved { get; set; }
    }
}