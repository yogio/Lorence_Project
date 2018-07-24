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

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }

        //can be used for Fluet API
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            /*
            modelBuilder.Entity<User>()
                .HasKey(c => c.UserID)
                .HasMany(c => c.Orders);
                */
                //
            //modelBuilder.Entity<Order>().Property(d => d.DateCreated).HasDatabaseGeneratedOption("getdate()");
       }

    }
}