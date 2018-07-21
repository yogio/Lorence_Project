using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using Lorence_Project.Models;

namespace Lorence_Project.DAL
{
    public class LorenceDbContext : DbContext
    {
        public LorenceDbContext() : base("LorenceDbContext") { }

        public DbSet<Drink> Drinks { get; set; }
        //public DbSet<Sit> Sits { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}