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
                new User{UserID = 2, userKind = User.UserKind.Client, UserName = "Client", Password = "Change12!"},
                new User{UserID = 3, userKind = User.UserKind.Employee, UserName = "Waiter", Password = "Change23!"}
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
            var sits = new List<Order>
            {
                new Order{ OrderID = 1, SitName = "Sit 1", DateOrdered = DateTime.Now, orderDate = DateTime.Now.AddDays(2.0),
                    arrived = null, confirmedByAdmin = null,
                    UserID = users.Single(s=> s.UserName == "Admin").UserID},
                new Order{ OrderID = 2, SitName = "Sit 2", DateOrdered = DateTime.Now, orderDate = DateTime.Now.AddDays(3.0),
                    arrived = null, confirmedByAdmin = null,
                    UserID = users.Single(s=> s.UserName == "Client").UserID} 
            };
            sits.ForEach(s => context.Orders.Add(s));
            context.SaveChanges();

            var orders = new List<OrderProduct>
            {
                new OrderProduct{OrderProductID = 1, productID = 1, OrderID = 1},
                new OrderProduct{OrderProductID = 2, productID = 3, OrderID = 1},
                new OrderProduct{OrderProductID = 3, productID = 4, OrderID = 2}
            };
            orders.ForEach(o => context.OrderProducts.Add(o));
            context.SaveChanges();
        }
    }
}