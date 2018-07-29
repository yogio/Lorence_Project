namespace Lorence.Migrations
{
    using Lorence.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Lorence.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Lorence.Models.ApplicationDbContext context)
        {
            //creating the Administrator, Employee and Client Roles
            if (!context.Roles.Any(r => r.Name == "Administrator"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Administrator" };

                manager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "Employee"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Employee" };

                manager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "Client"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Client" };

                manager.Create(role);
            }


            //Creating Users: Admin, Employee1 and Client1
            if (!context.Users.Any(u => u.UserName == "Admin@lorence.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser
                {
                    UserName = "Admin@lorence.com",
                    Email = "Admin@lorence.com",
                    EmailConfirmed = true
                };

                manager.Create(user, "Aa12346!");
                manager.AddToRole(user.Id, "Administrator");
            }

            if (!context.Users.Any(u => u.UserName == "Employee1@lorence.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser
                {
                    UserName = "Employee1@lorence.com",
                    Email = "Employee1@lorence.com",
                    EmailConfirmed = true
                };

                manager.Create(user, "Aa12346!");
                manager.AddToRole(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "Client1@lorence.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser
                {
                    UserName = "Client1@lorence.com",
                    Email = "Client1@lorence.com",
                    EmailConfirmed = true
                };

                manager.Create(user, "Aa12346!");
                manager.AddToRole(user.Id, "Client");
            }

            //Creating Products: Beer, Wine and Burger
            var products = new List<Product>
            {
                new Product{ProductKind = ProductKind.Drink, ProductName = "Beer"},
                new Product{ProductKind = ProductKind.Drink, ProductName = "Wine"},
                new Product{ProductKind = ProductKind.Food, ProductName = "Burger"}
            };
            products.ForEach(c => context.Products.Add(c));
            context.SaveChanges();

            //Creating Sits: 1 - Table, 2 - Table, 1 - Bar and 2 - Bar
            var sits = new List<Sit>
            {
                new Sit{SitKind = SitKind.Table, SitName = "1"},
                new Sit{SitKind = SitKind.Table, SitName = "2"},
                new Sit{SitKind = SitKind.Bar, SitName = "1"},
                new Sit{SitKind = SitKind.Bar, SitName = "2"}
            };
            sits.ForEach(c => context.Sits.Add(c));
            context.SaveChanges();

            //Creating the Orders: 
            //The admin orders the Table - 1 for the date of two days after today.
            //The Employee order the Bar - 2 for the date of three days after today.
            //The Client orders the Table - 2 for the date of the next day after today.
            //The Client orders the Bar - 1 for the date of five days after today.

            var orders = new List<Order>
            {
                new Order{UserID = context.Users.First(c => c.Email == "Admin@lorence.com").Id,
                    DateCreated = DateTime.Now.Date,
                    SitID = context.Sits.First(s => (s.SitName == "1" && s.SitKind.ToString() == SitKind.Table.ToString())).SitID,
                    TimeOrdered = DateTime.Now.AddDays(2.0)},

                new Order{UserID = context.Users.First(c => c.Email == "Employee1@lorence.com").Id,
                    DateCreated = DateTime.Now.Date,
                    SitID = context.Sits.First(s => (s.SitName == "2" && s.SitKind.ToString() == SitKind.Bar.ToString())).SitID,
                    TimeOrdered = DateTime.Now.AddDays(3.0) },

                new Order{UserID = context.Users.First(c => c.Email == "Client1@lorence.com").Id, DateCreated = DateTime.Now.Date,
                    SitID = context.Sits.First(s => (s.SitName == "2" && s.SitKind.ToString() == SitKind.Table.ToString())).SitID,
                    TimeOrdered = DateTime.Now.AddDays(1.0) },
                new Order{UserID = context.Users.First(c => c.Email == "Client1@lorence.com").Id, DateCreated = DateTime.Now.Date,
                    SitID = context.Sits.First(s => (s.SitName == "1" && s.SitKind.ToString() == SitKind.Bar.ToString())).SitID,
                    TimeOrdered = DateTime.Now.AddDays(5.0) }
            };
            orders.ForEach(c => context.Orders.Add(c));
            context.SaveChanges();

            //Adding Products that the Orders made.
            //Order #1 - ordered a burger and Beer.
            //Order #2 - nothing.
            //Order #3 - ordered Wine
            //Order #4 - Ordered 2 Burgers, 2 Beers and 3 Wines
            var orderproducts = new List<OrderProduct>
            {
                //Order #1
                new OrderProduct{ProductID = context.Products.First(c => c.ProductName == "Beer").ProductID,
                OrderID = 1 },
                new OrderProduct{ProductID = context.Products.First(c => c.ProductName == "Burger").ProductID,
                OrderID = 1 },
                //Order #3
                new OrderProduct{ProductID = context.Products.First(c => c.ProductName == "Wine").ProductID,
                OrderID = 3 },
                //Order #4
                new OrderProduct{ProductID = context.Products.First(c => c.ProductName == "Burger").ProductID,
                OrderID = 4 },
                new OrderProduct{ProductID = context.Products.First(c => c.ProductName == "Burger").ProductID,
                OrderID = 4 },
                new OrderProduct{ProductID = context.Products.First(c => c.ProductName == "Beer").ProductID,
                OrderID = 4 },
                new OrderProduct{ProductID = context.Products.First(c => c.ProductName == "Beer").ProductID,
                OrderID = 4 },
                new OrderProduct{ProductID = context.Products.First(c => c.ProductName == "Wine").ProductID,
                OrderID = 4 }

            };
            orderproducts.ForEach(c => context.OrderProducts.Add(c));
            context.SaveChanges();


        }
    }
}
