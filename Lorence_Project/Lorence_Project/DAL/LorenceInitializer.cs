using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Lorence_Project.Models;

namespace Lorence_Project.DAL
{
    public class LorenceInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<LorenceDbContext>
    {
        protected override void Seed(LorenceDbContext context)
        {
            
            //list of users
            var users = new List<User>
            {
                new User{Password = "Change12!", UserName = "Admin", userKind = UserKind.Administrator},
                new User{Password = "PassW0rd", UserName = "Client", userKind = UserKind.Client},
                new User{Password = "Aa123454!", UserName = "Emp", userKind = UserKind.Employee}
            };
            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();

            var orders = new List<Order>
            {
                new Order{Time = DateTime.Parse("20:00"), Date = DateTime.Now.Date.AddDays(3.0), Sit = "1", UserID = 1},
                new Order{Time = DateTime.Parse("21:00"),Date = DateTime.Now.Date.AddDays(2.0), Sit = "1", UserID = 1}
            };
            orders.ForEach(o => context.Orders.Add(o));
            context.SaveChanges();
        }

    }
}