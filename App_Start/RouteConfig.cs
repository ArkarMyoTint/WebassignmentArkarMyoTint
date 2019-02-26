using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StarLight_Ticket
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

            routes.MapRoute(
                name:"cinema_saving",
                url: "{controller}/{action}/{id}/{name}/{mname}/{loca}/{sdate}/{price}",
                defaults:new { controller = "Cinema_Save", action = "Create", id = UrlParameter.Optional, name=UrlParameter.Optional, mname=UrlParameter.Optional, loca=UrlParameter.Optional, sdate=UrlParameter.Optional, price=UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "theatre_saving",
                url: "{controller}/{action}/{id}/{name}/{mname}/{loca}/{sdate}/{price}",
                defaults: new { controller = "Theatre_Save", action = "Create", id = UrlParameter.Optional, name = UrlParameter.Optional, mname = UrlParameter.Optional, loca = UrlParameter.Optional, sdate = UrlParameter.Optional, price = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "sport_saving",
                url: "{controller}/{action}/{id}/{name}/{mname}/{loca}/{sdate}/{price}",
                defaults: new { controller = "Sport_Save", action = "Create", id = UrlParameter.Optional, name = UrlParameter.Optional, mname = UrlParameter.Optional, loca = UrlParameter.Optional, sdate = UrlParameter.Optional, price = UrlParameter.Optional }
                );


        }
    }
}
