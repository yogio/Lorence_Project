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

            var drinks = new List<Drink>
            {
                new Drink{ DrinkName = "Beer"},
                new Drink{DrinkName = "Wine"},
                new Drink{DrinkName = "Cooctail"},
                new Drink{DrinkName = "test"}
            };
            drinks.ForEach(d => context.Drinks.Add(d));
            context.SaveChanges();

           // base.Seed(context);
        }
    }
}