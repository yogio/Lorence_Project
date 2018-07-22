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
            var product = new List<Product>
            {
                new Product{ ProductID = 1, productKind = ProductKind.Drink, productName = "Beer"},
                new Product{ProductID = 2, productKind = ProductKind.Drink, productName = "Wine"},
                new Product{ProductID = 3, productKind = ProductKind.Drink, productName = "Cooctail"},
                new Product{ProductID = 4, productKind = ProductKind.Food, productName = "Burger"},
            };
            product.ForEach(d => context.Products.Add(d));
            context.SaveChanges();

            //list of Orders of Sits
            var sits = new List<OrderSit>
            {
                new OrderSit{ OrderSitID = 1, SitName = "Sit 1", dateOrdered = DateTime.Parse(DateTime.Now.ToString()), orderDate = DateTime.Now.AddDays(2.0),
                    arrived = null, confirmedByAdmin = null,
                    UserID = users.Single(s=> s.UserName == "Admin").UserID},
                new OrderSit{ OrderSitID = 2, SitName = "Sit 2", dateOrdered = DateTime.Parse(DateTime.Now.ToString()), orderDate = DateTime.Now.AddDays(3.0),
                    arrived = null, confirmedByAdmin = null,
                    UserID = users.Single(s=> s.UserName == "firstClient").UserID } 
            };
            sits.ForEach(s => context.OrderSits.Add(s));
            context.SaveChanges();
        }
    }
}