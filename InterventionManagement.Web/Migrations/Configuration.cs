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

            SeedRoles(context);
            SeedUsers(context);
            SeedDistricts(context);
            SeedClients(context);
            SeedInterventionStates(context);
            SeedInterventionTemplates(context);
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
            // define users
            var hasher = new PasswordHasher();
            string password = hasher.HashPassword("testTEST12-");
            string securityStamp = "a09sXOsthox90oeE"; // needed to prevent null error http://stackoverflow.com/questions/21918000/mvc5-vs2012-identity-createidentityasync-value-cannot-be-null

            var accountant = new ApplicationUser { UserName = "accountant@test.com", Email = "accountant@test.com", PasswordHash = password, SecurityStamp = securityStamp, Hours = null, Cost = null };
            var engineer = new ApplicationUser { UserName = "test@test.com", Email = "test@test.com", PasswordHash = password, SecurityStamp = securityStamp, Hours = 25, Cost = 1000.00M };
            var manager = new ApplicationUser { UserName = "manager@test.com", Email = "manager@test.com", PasswordHash = password, SecurityStamp = securityStamp, Hours = 100, Cost = 5000.00M };

            // add them, or update them if necessary
            context.Users.AddOrUpdate(u => u.UserName, engineer, accountant, manager);
            context.SaveChanges(); // explicity save users, so context.Users.Any() returns true below

            if (context.Users.Any())
            {
                // add users to roles
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                userManager.AddToRole(accountant.Id, "Accountant");
                userManager.AddToRole(engineer.Id, "Engineer");
                userManager.AddToRole(manager.Id, "Manager");
            }
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

        private void SeedInterventionStates(ApplicationDbContext context)
        {
            context.InterventionState.AddOrUpdate(
                i => i.Name,
                new InterventionState{ InterventionStateId=1, Name="Proposed" },
                new InterventionState{ InterventionStateId=2, Name="Approved" },
                new InterventionState{ InterventionStateId=3, Name="Cancelled" },
                new InterventionState{ InterventionStateId=4, Name="Completed" }
                );
        }

        private void SeedInterventionTemplates(ApplicationDbContext context)
        {
            context.InterventionTemplate.AddOrUpdate(
                i => i.Name,  
                new InterventionTemplate{ InterventionTemplateId=1, Name="Supply Mosquito Net", Hours=1, Cost=60.00M },
                new InterventionTemplate{ InterventionTemplateId=1, Name="Supply and Install Storm-proof Home Kit", Hours=40, Cost=1000.00M },
                new InterventionTemplate{ InterventionTemplateId=1, Name="Supply and Install Portable Toilet", Hours=4, Cost=150.00M },
                new InterventionTemplate{ InterventionTemplateId=1, Name="Hepatitis Avoidance Training", Hours=3, Cost=80.00M }
                );
        }
    }
}
