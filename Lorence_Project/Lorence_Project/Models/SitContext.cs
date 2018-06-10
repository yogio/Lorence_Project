using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Lorence_Project.Models
{
    public class SitContext : DbContext
    {
        public DbSet<Sit> SitC { get; set; }

    }
}