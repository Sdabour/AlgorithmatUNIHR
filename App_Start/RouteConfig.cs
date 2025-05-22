using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AlgorithmatMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "login", action = "index", id = UrlParameter.Optional }
            //);
            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "login", action = "index", id = UrlParameter.Optional }
           );
            routes.MapRoute(
              name: "Default1",
              url: "{controller}/{action}/"
          );
            routes.MapRoute(
           name: "DefalutWithStrTemp",
           url: "{controller}/{action}/strTemp"
       );
            routes.MapRoute(name: "DefaultApi", url: "api/{controller}/{action}/{id}", defaults: new { id = UrlParameter.Optional });
        }
    }
}
