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

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            /* i don't need this anymore
            modelBuilder.Entity<Product>()
                .HasMany(c => c.OrderSits).WithMany(i => i.Products)
                .Map(t => t.MapLeftKey("ProductID")
                .MapRightKey("OrderSitID")
                .ToTable("OrderSitProduct"));

            modelBuilder.Entity<User>()
                .HasMany(c => c.OrderSits).WithMany(f => f.Users)
                .Map(r => r.MapLeftKey("UserID")
                .MapRightKey("OrderSits").ToTable("OrderesByUsers"));

    */

        }

    }
}