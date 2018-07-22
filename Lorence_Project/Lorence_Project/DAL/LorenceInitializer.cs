using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Lorence_Project.Models;

namespace Lorence_Project.DAL
{
    public class LorenceInitializer : System.Data.Entity.DropCreateDatabaseAlways<LorenceDbContext>
    {
        protected override void Seed(LorenceDbContext context)
        {
            //list of users
            var users = new List<User>
            {
                new User{UserID = 1, userKind = User.UserKind.Administrator,UserName = "Admin",Password = "P@ssW0rd"},
                new User{UserID = 2, userKind = User.UserKind.Client, UserName = "firstClient", Password = "Change12!"}
            };
            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();


            //list of products
            var drinks = new List<Product>
            {
                new Product{ ProductID = 1, productKind = ProductKind.Drink, ProductName = "Beer"},
                new Product{ProductID = 2, productKind = ProductKind.Drink, ProductName = "Wine"},
                new Product{ProductID = 3, productKind = ProductKind.Drink, ProductName = "Cooctail"},
                new Product{ProductID = 4, productKind = ProductKind.Food, ProductName = "Burger"},
            };
            drinks.ForEach(d => context.Products.Add(d));
            context.SaveChanges();

            //list of Orders of Sits
            var sits = new List<OrderSit>
            {
                new OrderSit{ OrderSitID = 1, SitName = "Sit 1", date = DateTime.Now, arrived = null, confirmedByAdmin = null, UserID = users.Single(s=> s.UserName == "Admin").UserID}
            };
            sits.ForEach(s => context.OrderSits.Add(s));
            context.SaveChanges();
        }
    }
}