using System;
using System.IO;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Web;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.DataLayerWrappers;
using Microsoft.Owin;
using Owin;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.Identity;

[assembly: OwinStartup(typeof(Startup))]
namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            // Set DataDirectory for the connection string in Web.config
            string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\InterventionManagement.Data"));
            AppDomain.CurrentDomain.SetData("DataDirectory", path);

            // Initialize the database
            new DatabaseInitializer().InitializeDatabase();
            new IdentityWrapper().InitializeRoles();
        }
    }
}
