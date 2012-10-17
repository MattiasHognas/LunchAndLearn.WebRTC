using System.Web.Mvc;
using System.Web.Routing;

namespace WebRTC.UI.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            SignalR.RouteExtensions.MapHubs(routes);

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Default", "{controller}/{action}/{id}",
                            new { controller = "Home", action = "Snapshot", id = UrlParameter.Optional }
                );
        }
    }
}