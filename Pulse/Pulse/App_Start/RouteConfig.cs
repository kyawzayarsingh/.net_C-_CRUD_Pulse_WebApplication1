using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Pulse
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //We used MapMvcAttributes becoz we are always not write MapRoute in RouteConfig again and again
            //instead of writing in RouteConfig, Instead, we can call in Controller [Route(.......)]
            //routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            //routes.MapRoute(
            //    "moviesByReleasedDate",
            //    "movies/released/{year}/{month}",
            //    new { controller = "Movies", action = "ByReleaseDate"},
            //    new {year = @"\d{4}", month=@"d\{2}"}
            //    );

            //routes.MapRoute(
            //    name: "AllBooks",
            //    url: "books",
            //    defaults: new { controller = "Book", action = "GetAllBooks" }
            //    );

            //routes.MapRoute(
            //    name: "BookDetailById",
            //    url: "books/{id}",
            //    defaults: new { controller = "Book", action = "GetBookById" },
            //    constraints: new {id= @"\d+"}
            //    );

            //routes.MapRoute(
            //    name: "GetBookAddress",
            //    url: "books/{id}/Address",
            //    defaults: new { controller = "Book", action = "GetBookAddress" }
            //    );
        }
    }
}
