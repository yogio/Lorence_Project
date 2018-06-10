using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Lorence_Project.Models
{
    public class UserContext : DbContext
    {
        public DbSet<User> UserC { get; set; }
    }
}