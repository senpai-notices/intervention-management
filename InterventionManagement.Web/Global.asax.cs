using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ASDF.ENETCare.InterventionManagement.Data


namespace InterventionManagement.Web
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
            SetDataDirectory();
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
            ASDF.ENETCare.InterventionManagement.Data.Startup.InitializeDatabase();
        }
    }
}
