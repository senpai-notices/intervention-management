using ASDF.ENETCare.InterventionManagement.Web.Models;

namespace ASDF.ENETCare.InterventionManagement.Web.Migrations
{
    using Business;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            SeedDistricts(context);
            SeedClients(context);
        }

        private void SeedDistricts(ApplicationDbContext context)
        {
            context.District.AddOrUpdate(
                d => d.Name,
                new District { Name = "Urban Indonesia" },
                new District { Name = "Rural Indonesia" },
                new District { Name = "Urban Papua New Guinea" },
                new District { Name = "Rural Papua New Guinea" },
                new District { Name = "Sydney" },
                new District { Name = "Rural New South Wales" }
                );
        }

        private void SeedClients(ApplicationDbContext context)
        {
            context.Client.AddOrUpdate(
                c => c.Name,
                new Client { Name = "Family of Josiah and Ruth", Location = "Blue tin shack, underneath wooden bridge", DistrictId = 1 },
                new Client { Name = "Bambang Bima", Location = "1 Agung Road", DistrictId = 2 },
                new Client { Name = "Susilo Sinta", Location = "25 Wira Street", DistrictId = 3 },
                new Client { Name = "Rodney McDonald", Location = "100 Nelson Highway, Wagga Wagga", DistrictId = 4 }
                );
        }
    }
}
