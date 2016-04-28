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
            //var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
            //RoleManager.Create(new IdentityRole("EngineerX"));
            //RoleManager.Create(new IdentityRole("ManagerX"));
            //RoleManager.Create(new IdentityRole("AccountantX"));
            TryInitializeRole("EngineerX");
            TryInitializeRole("ManagerX");
            TryInitializeRole("AccountantX");
        }

        private void TryInitializeRole(string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            if (!roleManager.RoleExists(roleName))
            {
                roleManager.Create(new IdentityRole(roleName));
            }
        }

        public void CreateUser()
        {
            //var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>());
            //var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
            ////var myinfo = new MyUserInfo() { FirstName = "Pranav", LastName = "Rastogi" };
            //string name = "Admin";
            //string password = "123456";
            //string test = "test";

            ////Create Role Test and User Test
            //RoleManager.Create(new IdentityRole(test));
            //UserManager.Create(new ApplicationUser() { UserName = test });

            ////Create Role Admin if it does not exist
            //if (!RoleManager.RoleExists(name))
            //{
            //    var roleresult = RoleManager.Create(new IdentityRole(name));
            //}
        }
    }
}
