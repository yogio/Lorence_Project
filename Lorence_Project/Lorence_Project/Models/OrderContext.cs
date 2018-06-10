using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Lorence_Project.Models
{
    public class OrderContext : DbContext
    {
        public DbSet<Order> OrderC { get; set; }
    }
}