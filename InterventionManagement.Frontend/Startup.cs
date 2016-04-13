using System;
using System.IO;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Web;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);

            // Added
            string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\au.edu.uts.ASDF.ENETCare.InterventionManagement.Data"));
            AppDomain.CurrentDomain.SetData("DataDirectory", path);

        }
    }
}
