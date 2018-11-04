namespace Topx.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Topx.Data.ModelTopX>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Topx.Data.ModelTopX";
        }

        protected override void Seed(Topx.Data.ModelTopX context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
