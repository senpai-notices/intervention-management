﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Web.Models;
using System.Web.UI;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Web.Identity
{
    public class IdentityWrapper
    {
        // encapsulates Identity functions
        public IdentityWrapper()
        {

        }

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
                userManager.AddToRole(user.Id, roleName);
            }
            else
            {
                // throw exception
            }
        }

        public void SignIn(ApplicationUserManager userManager, ApplicationSignInManager signInManager, string username, string password)
        {
            var user = userManager.FindByName(username);
            if (user != null)
            {
                if (userManager.CheckPassword(user, password))
                {
                    signInManager.SignIn(user, false, false);
                }
                else
                {
                    //throw exception
                }
            }
        }
    }
}