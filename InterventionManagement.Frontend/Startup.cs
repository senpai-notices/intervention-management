using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InterventionManagement.Frontend.Startup))]
namespace InterventionManagement.Frontend
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
