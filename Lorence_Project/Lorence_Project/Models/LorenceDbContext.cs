using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

//The DbContext class allows us to let the EF know which Entities are included in the
//data model.
//this also allows us to customize EF's behavior.
namespace Lorence_Project.Models
{
    public class LorenceDbContext : DbContext
    {
        //this C'Tor is in case we will want to change the String name
        //of DbContext of the site.
        //if not mentioned, that String name will be LorenceDbContext, thus
        //i added it to in case we will want to change it, otherwise 
        //it's mentioned explicitly with no other reason.
        public LorenceDbContext() : base("LorenceDbContext") { }

        //mentioning the DB's that are related to each other.
        //we will notice that the fact Orders are calling for the creation of Drinks and Sits
        //is created by the fact it holds these DB's, but we mention them here for easier code reading.
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Sit> Sits { get; set; }
        public DbSet<User> Users { get; set; }

        //this is used to make sure EF won't turn the names we just created
        //into pluralized names, as we already gave them pluralized names ourselves.
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }


    }
}