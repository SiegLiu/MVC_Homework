using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC_Homework
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "SkillTree",
                url: "SkillTree/{controller}/{action}/{id}",
                defaults: new { controller = "KeepAccountWithService", action = "KeepAccounts", id = UrlParameter.Optional },
                namespaces: new[] { "MVC_Homework.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces:new[] {"MVC_Homework.Controllers"}
            );
        }
    }
}
