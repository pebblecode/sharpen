using System.Web.Mvc;
using System.Web.Routing;

namespace MvcApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                name: "Test",
                url: "Test/{action}/{id}",
                defaults: new { controller = "Test", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}