using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InterventionManagement.Web.Startup))]
namespace InterventionManagement.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
