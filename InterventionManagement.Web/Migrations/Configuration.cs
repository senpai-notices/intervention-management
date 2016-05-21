using ASDF.ENETCare.InterventionManagement.Web.Models;

namespace ASDF.ENETCare.InterventionManagement.Web.Migrations
{
    using Business;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
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

            // You can use the AddOrUpdate() method to avoid creating duplicate seed data:
            // context.People.AddOrUpdate(
            //     p => p.FullName,
            //     new Person { FullName = "Andrew Peters" },
            //     new Person { FullName = "Brice Lambson" },
            //     );

            SeedRoles(context);
            SeedUsers(context);
        }

        private void SeedRoles(ApplicationDbContext context)
        {
            if (!context.Roles.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                var accountantRole = new IdentityRole { Name = "Accountant" };
                var engineerRole = new IdentityRole { Name = "Engineer" };
                var managerRole = new IdentityRole { Name = "Manager" };

                roleManager.Create(accountantRole);
                roleManager.Create(engineerRole);
                roleManager.Create(managerRole);
            }
        }

        private void SeedUsers(ApplicationDbContext context)
        {
            //if (!context.Users.Any())
            //{
            //    var userStore = new UserStore<ApplicationUser>(context);
            //    var userManager = new UserManager<ApplicationUser>(userStore);

            //    var engineer = new ApplicationUser { UserName = "test@test.com", Email = "test@test.com" };
            //    var accountant = new ApplicationUser { UserName = "accountant@test.com", Email = "accountant@test.com" };
            //    var manager = new ApplicationUser { UserName = "manager@test.com", Email = "manager@test.com" };
            //    string commonPassword = "testTEST12-";

            //    userManager.Create(accountant, commonPassword);
            //    userManager.AddToRole(engineer.Id, "Accountant");

            //    userManager.Create(engineer, commonPassword);
            //    userManager.AddToRole(engineer.Id, "Engineer");

            //    userManager.Create(manager, commonPassword);
            //    userManager.AddToRole(engineer.Id, "Manager");
            //}
            var hasher = new PasswordHasher();
            string password = hasher.HashPassword("testTEST12-");

            var accountant = new ApplicationUser { UserName = "accountant@test.com", Email = "accountant@test.com" };
            var engineer = new ApplicationUser { UserName = "test@test.com", Email = "test@test.com" };
            var manager = new ApplicationUser { UserName = "manager@test.com", Email = "manager@test.com" };

            context.Users.AddOrUpdate(u => u.UserName, engineer, accountant, manager);

            if (context.Users.Any())
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                userManager.AddToRole(accountant.Id, "Accountant");
                userManager.AddToRole(engineer.Id, "Engineer");
                userManager.AddToRole(manager.Id, "Manager");
            }
        }
        //private void SeedDistricts(ApplicationDbContext context)
        //{
        //    context.District.AddOrUpdate(
        //        d => d.Name,
        //        new District { Name = "Urban Indonesia" },
        //        new District { Name = "Rural Indonesia" },
        //        new District { Name = "Urban Papua New Guinea" },
        //        new District { Name = "Rural Papua New Guinea" },
        //        new District { Name = "Sydney" },
        //        new District { Name = "Rural New South Wales" }
        //        );
        //}

        //private void SeedClients(ApplicationDbContext context)
        //{
        //    context.Client.AddOrUpdate(
        //        c => c.Name,
        //        new Client { Name = "Family of Josiah and Ruth", Location = "Blue tin shack, underneath wooden bridge", DistrictId = 1 },
        //        new Client { Name = "Bambang Bima", Location = "1 Agung Road", DistrictId = 2 },
        //        new Client { Name = "Susilo Sinta", Location = "25 Wira Street", DistrictId = 3 },
        //        new Client { Name = "Rodney McDonald", Location = "100 Nelson Highway, Wagga Wagga", DistrictId = 4 }
        //        );
        //}
    }
}
