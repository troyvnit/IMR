using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace IMR
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name:"Contact",
                url: "{culture}/{contact}",
                defaults: new { controller = "Home", action = "Contact", culture = UrlParameter.Optional },
                constraints: new { contact = new ContactConstraint() }
            );

            routes.MapRoute(
                name: "ArticleInternationalization",
                url: "{culture}/a/{category}/{seoTitle}",
                defaults: new { controller = "Home", action = "Article", seoTitle = UrlParameter.Optional },
                constraints: new { culture = "[a-z]{2}" }
            );

            routes.MapRoute(
                name: "Article",
                url: "a/{category}/{seoTitle}",
                defaults: new { controller = "Home", action = "Article", seoTitle = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Internationalization",
                url: "{culture}/{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                constraints: new { culture = "[a-z]{2}" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }

    public class ContactConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            return values[parameterName].ToString().Equals(Resources.IMRResources.ResourceManager.GetString("Contact", CultureInfo.CreateSpecificCulture("en")), StringComparison.OrdinalIgnoreCase)
                || values[parameterName].ToString().Equals(Resources.IMRResources.ResourceManager.GetString("Contact", CultureInfo.CreateSpecificCulture("de")), StringComparison.OrdinalIgnoreCase)
                || values[parameterName].ToString().Equals(Resources.IMRResources.ResourceManager.GetString("Contact", CultureInfo.CreateSpecificCulture("vi")), StringComparison.OrdinalIgnoreCase); 
        }
    } 
}
