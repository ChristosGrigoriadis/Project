namespace UberTappDeveloping.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using UberTappDeveloping.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<UberTappDeveloping.DAL.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(UberTappDeveloping.DAL.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //var beers = new List<Beer>
            //{
                
            //};
            //beers.ForEach(s => context.Beers.AddOrUpdate(p => p.Name, s));
            //context.SaveChanges();
        }
    }
}
