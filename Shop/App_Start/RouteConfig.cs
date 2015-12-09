using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Shop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null,
                "",
                new {
                    Controller = "Equipment", Action = "List",
                    category = (string)null, page = 1
                }
            );

            routes.MapRoute(null,
                "Page{page}",
                new { Controller = "Equipment", Action = "List", category = (string)null },
                new { page = @"\d+" }
            );

            routes.MapRoute(null,
                "{category}",
                new { Controller = "Eq;uipment", Action = "List", page = 1 }
            );

            routes.MapRoute(null,
                "{category}/Page{page}",
                new { Controller = "Equipment", Action = "List" },
                new { page = @"\d+" }
            );            

            routes.MapRoute(null, "{Controller}/{Action}");
        }
    }
}
