namespace Lorence_Project.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Lorence_Project.Models.LorenceDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            //for testing, this is enabled, but for a production ready product we should set to false.
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Lorence_Project.Models.LorenceDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
