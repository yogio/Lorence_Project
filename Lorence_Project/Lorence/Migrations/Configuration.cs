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
                var user = new ApplicationUser { UserName = "Admin@lorence.com",
                    Email = "Admin@lorence.com",
                    EmailConfirmed = true };

                manager.Create(user, "Aa12346!");
                manager.AddToRole(user.Id, "Administrator");
            }

            if (!context.Users.Any(u => u.UserName == "Employee1@lorence.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "Employee1@lorence.com",
                    Email = "Employee1@lorence.com",
                    EmailConfirmed = true };

                manager.Create(user, "Aa12346!");
                manager.AddToRole(user.Id, "Employee");
            }

            if (!context.Users.Any(u => u.UserName == "Client1@lorence.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "Client1@lorence.com",
                    Email = "Client1@lorence.com",
                    EmailConfirmed = true };

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

            //Creating the Orders: The admin orders the Table - 1 for the date of two days after today.
            


        }


    }
}
