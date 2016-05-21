using ASDF.ENETCare.InterventionManagement.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ASDF.ENETCare.InterventionManagement.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Additional custom startup methods
            //SetDataDirectory();
            InitializeDatabase();
        }

        private void SetDataDirectory()
        {
            // Set DataDirectory for the connection string in Web.config
            string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\InterventionManagement.Data"));
            AppDomain.CurrentDomain.SetData("DataDirectory", path);
        }

        private void InitializeDatabase()
        {
            //ASDF.ENETCare.InterventionManagement.Data.Startup.InitializeDatabase();

        }

        //public void CreateRoles(List<string> roleNames)
        //{
        //    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
        //    foreach (string roleName in roleNames)
        //    {
        //        CreateRole(roleName, roleManager);
        //    }
        //}

        //public void CreateRole(string roleName, RoleManager<IdentityRole> roleManager)
        //{
        //    if (!roleManager.RoleExists(roleName))
        //    {
        //        roleManager.Create(new IdentityRole(roleName));
        //    }
        //}
    }
}
