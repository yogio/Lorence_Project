namespace Lorence_Project.Migrations
{
    using Lorence_Project.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Lorence_Project.Models.LorenceDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Lorence_Project.Models.LorenceDbContext context)
        {
            var SitOrder = new List<SitOrder>
            {
                new SitOrder{sitKind = SitKind.Table, SitLocation = "1"},
                new SitOrder{sitKind = SitKind.Table, SitLocation = "2"},
                new SitOrder{sitKind = SitKind.Bar, SitLocation = "1"},
                new SitOrder{sitKind = SitKind.Bar, SitLocation = "2"},
                new SitOrder{sitKind = SitKind.Table, SitLocation = "Out Side 1"}
            };
            foreach (var s in SitOrder)
            {
                context.SitOrders.Add(s);
            }
            context.SaveChanges();

            var order = new List<Order>
            {
                new Order{UserID = context.Users.Single(c => c.UserName == "Admin").Id,
                    Date = DateTime.Now.AddDays(2.0).AddHours(22.0),
                    SitID = context.SitOrders.First(c=>(c.SitLocation == "1" && c.sitKind == SitKind.Bar)).SitOrderID},

                    new Order{UserID = context.Users.Single(c => c.UserName == "Admin").Id,
                    Date = DateTime.Now.AddDays(3.0).AddHours(18.0),
                    SitID = context.SitOrders.First(c=>(c.SitLocation == "2" && c.sitKind == SitKind.Table)).SitOrderID }
            };
            foreach (var o in order)
                context.Orders.Add(o);
            context.SaveChanges();

            var products = new List<Product>
            {
                new Product{ProductName = "Beer", productKind = ProductKind.Drink, Description ="Blond Beer are awesome."},
                new Product{ProductName = "Burger", productKind = ProductKind.Food, Description = "Not healthy, but Tasty."}
            };
            foreach (var p in products)
                context.Products.Add(p);
            context.SaveChanges();

            var orderprod = new List<OrderProduct>
            {
                new OrderProduct{ProductID = context.Products.First(c=> c.ProductName == "Burger").ProductID,
                OrderID = context.Orders.First(c=>c.UserID == context.Users.First(f=>f.UserName == "Admin").Id).OrderID}
            };

            var role = new RoleStore<IdentityRole> { }
        }
    }
}
