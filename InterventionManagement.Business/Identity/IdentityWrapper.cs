using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.Identity
{
    public class IdentityWrapper
    {
        // encapsulates Identity functions

        public void InitializeRoles()
        {
            TryInitializeRole("Engineer");
            TryInitializeRole("Manager");
            TryInitializeRole("Accountant");
        }

        private void TryInitializeRole(string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            if (!roleManager.RoleExists(roleName))
            {
                roleManager.Create(new IdentityRole(roleName));
            }
        }

        public void CreateUser(string username, string password, string roleName)
        {
            // set up the required Managers
            var context = new ApplicationDbContext();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            //To Do: validate username, pw and role
            var user = new ApplicationUser() { UserName = username };
            IdentityResult createUser = userManager.Create(user, password);
            if (createUser.Succeeded)
            {
            }
            else
            {
                // throw exception
            }
        }
    }
}
