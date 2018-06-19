using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Lorence_Project.Models;


namespace Lorence_Project
{
    public class LorenceInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<LorenceDbContext>
    {
        //the seed is creating a "basic" DB which hold information we create.
        protected override void Seed(LorenceDbContext context)
        {
            //creating a "Wine" and "Beer" drinks
            var drinks = new List<Drink>
            {
                new Drink{ DrinkName = "Wine"},
                new Drink{ DrinkName = "Beer"}
            };
            //adding each Drink to the Drinks Table.
            drinks.ForEach(d => context.Drinks.Add(d));
            context.SaveChanges();

            //adding 3 sits, later we will create differant kinds of sits, but for now we 
            //only call them by their kind.
            var sits = new List<Sit>
            {
                new Sit{ SitName = "1" },
                new Sit{ SitName = "2" },
                new Sit{SitName = "out side"}
            };

            sits.ForEach(s => context.Sits.Add(s));
            context.SaveChanges();

            var users = new List<User>
            {
                new User{ Name = "Guy", Password = "123456"},
                new User{ Name = "Yogev", Password = "123456"},
                new User{Name = "Rotem", Password = "654321"}
            };

            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();
        }
    }

    
}