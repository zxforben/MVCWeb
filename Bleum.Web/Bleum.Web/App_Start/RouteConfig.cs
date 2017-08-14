using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Bleum.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            /*1st declare way*/
            routes.MapRoute(
                name: "hello",
                url: "{controller}/{action}/{name}/{numTimes}"
                );

            /*2nd declare way*/
            Route myRoute = new Route("{controller}/{action}", new MvcRouteHandler());
            routes.Add("MyRoute", myRoute);

            /*3rd declare way*/
            routes.MapRoute("ShopSchema", "shop/{action}", new { controller = "Home" });

            routes.MapRoute("ShopSchema2", "Shop/OldAction", new { controller = "home", action = "Index" });

            routes.MapRoute("ShopSchema3", "Shop/{action}", new { controller = "Home" });

            routes.MapRoute("ShopSchema2", "Shop/OldAction.js", new { controller = "Home", action = "Index" });

            routes.MapRoute("myRoute2", "{controller}/{action}/{id}", new
            {
                controller = "Home",
                action = "Index",
                id = "DefaultId"
            });

            routes.IgnoreRoute("Content/{filename}.html");


        }
    }
}
