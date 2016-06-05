using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ASDF.ENETCare.InterventionManagement.Business
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            // This method will be called after migrating to the latest version.

            // The order of these methods is important
            SeedRoles(context);
            SeedDistricts(context);
            SeedUsers(context);
            SeedClients(context);
            SeedInterventionStates(context);
            SeedInterventionTemplates(context);
        }

        private void SeedRoles(ApplicationDbContext context)
        {
            if (!context.Roles.Any())
            {
                /*var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                var accountantRole = new IdentityRole { Name = "Accountant" };
                var engineerRole = new IdentityRole { Name = "Engineer" };
                var managerRole = new IdentityRole { Name = "Manager" };

                roleManager.Create(accountantRole);
                roleManager.Create(engineerRole);
                roleManager.Create(managerRole);*/

                var roleStore = new RoleStore<CustomRole, int, CustomUserRole>(context);
                var roleManager = new ApplicationRoleManager(roleStore);

                var accountantRole = new CustomRole { Name = "Accountant" };
                var engineerRole = new CustomRole { Name = "Engineer" };
                var managerRole = new CustomRole { Name = "Manager" };

                roleManager.Create(accountantRole);
                roleManager.Create(engineerRole);
                roleManager.Create(managerRole);

            }
        }

        private void SeedUsers(ApplicationDbContext context)
        {
            // define users
            var hasher = new PasswordHasher();
            const string password = "testTEST12-";

            var newUsers = new List<ApplicationUser>
            {
                new ApplicationUser { Name = "Adam", UserName = "accountant@test.com", Email = "accountant@test.com", PasswordHash = hasher.HashPassword(password), SecurityStamp = Guid.NewGuid().ToString(), Hours = null, Cost = null, DistrictId = null },
                new ApplicationUser { Name = "Edward", UserName = "test@test.com", Email = "test@test.com", PasswordHash = hasher.HashPassword(password), SecurityStamp = Guid.NewGuid().ToString(), Hours = 25, Cost = 1000.00M, DistrictId = 1 },
                new ApplicationUser { Name = "Mike", UserName = "manager@test.com", Email = "manager@test.com", PasswordHash = hasher.HashPassword(password), SecurityStamp = Guid.NewGuid().ToString(), Hours = 100, Cost = 5000.00M, DistrictId = 1 },
                new ApplicationUser { Name = "Anna", UserName = "accountant2@test.com", Email = "accountant2@test.com", PasswordHash = hasher.HashPassword(password), SecurityStamp = Guid.NewGuid().ToString(), Hours = null, Cost = null, DistrictId = null },
                new ApplicationUser { Name = "Edgar", UserName = "test2@test.com", Email = "test2@test.com", PasswordHash = hasher.HashPassword(password), SecurityStamp = Guid.NewGuid().ToString(), Hours = 25, Cost = 2000.00M, DistrictId = 2 },
                new ApplicationUser { Name = "Mark", UserName = "manager2@test.com", Email = "manager2@test.com", PasswordHash = hasher.HashPassword(password), SecurityStamp = Guid.NewGuid().ToString(), Hours = 100, Cost = 7500.00M, DistrictId = 2 }
            };

            context.Users.AddOrUpdate(u => u.UserName, newUsers.ToArray());
            context.SaveChanges();

            if (context.Users.Any())
            {
                // add users to roles
                var userStore = new UserStore<ApplicationUser, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>(context);
                var userManager = new UserManager<ApplicationUser, int>(userStore);

                userManager.AddToRole(newUsers.ElementAt(0).Id, "Accountant");
                userManager.AddToRole(newUsers.ElementAt(1).Id, "Engineer");
                userManager.AddToRole(newUsers.ElementAt(2).Id, "Manager");

                userManager.AddToRole(newUsers.ElementAt(3).Id, "Accountant");
                userManager.AddToRole(newUsers.ElementAt(4).Id, "Engineer");
                userManager.AddToRole(newUsers.ElementAt(5).Id, "Manager");
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
