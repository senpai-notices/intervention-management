using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Web
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);
        }
    }
}
