namespace Lorence_Project.Migrations
{
    using Lorence_Project.Models;
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
            var users = new List<AspNetUsers>
            {
                
            };
        }
    }
}
