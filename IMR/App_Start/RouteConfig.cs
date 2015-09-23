using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using IMR.Utils;

namespace IMR
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.LowercaseUrls = true;

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name:"Contact",
                url: "{culture}/{contact}",
                defaults: new { controller = "Home", action = "Contact", culture = UrlParameter.Optional },
                constraints: new { contact = new ContactConstraint() }
            );

            routes.MapRoute(
                name: "Disclaimer",
                url: "{culture}/{disclaimer}",
                defaults: new { controller = "Home", action = "Disclaimer", culture = UrlParameter.Optional },
                constraints: new { disclaimer = new DisclaimerConstraint() }
            );

            routes.MapRoute(
                name: "Quality",
                url: "{culture}/{quality}",
                defaults: new { controller = "Home", action = "Quality", culture = UrlParameter.Optional },
                constraints: new { quality = new QualityConstraint() }
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
            return values[parameterName].ToString().Equals(Resources.IMRResources.ResourceManager.GetString("Contact", CultureInfo.CreateSpecificCulture("en")).GenerateSeoTitle(), StringComparison.OrdinalIgnoreCase)
                || values[parameterName].ToString().Equals(Resources.IMRResources.ResourceManager.GetString("Contact", CultureInfo.CreateSpecificCulture("de")).GenerateSeoTitle(), StringComparison.OrdinalIgnoreCase)
                || values[parameterName].ToString().Equals(Resources.IMRResources.ResourceManager.GetString("Contact", CultureInfo.CreateSpecificCulture("vi")).GenerateSeoTitle(), StringComparison.OrdinalIgnoreCase); 
        }
    }

    public class DisclaimerConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            return values[parameterName].ToString().Equals(Resources.IMRResources.ResourceManager.GetString("Disclaimer", CultureInfo.CreateSpecificCulture("en")).GenerateSeoTitle(), StringComparison.OrdinalIgnoreCase)
                || values[parameterName].ToString().Equals(Resources.IMRResources.ResourceManager.GetString("Disclaimer", CultureInfo.CreateSpecificCulture("de")).GenerateSeoTitle(), StringComparison.OrdinalIgnoreCase)
                || values[parameterName].ToString().Equals(Resources.IMRResources.ResourceManager.GetString("Disclaimer", CultureInfo.CreateSpecificCulture("vi")).GenerateSeoTitle(), StringComparison.OrdinalIgnoreCase);
        }
    }

    public class QualityConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            return values[parameterName].ToString().Equals(Resources.IMRResources.ResourceManager.GetString("Quality", CultureInfo.CreateSpecificCulture("en")).GenerateSeoTitle(), StringComparison.OrdinalIgnoreCase)
                || values[parameterName].ToString().Equals(Resources.IMRResources.ResourceManager.GetString("Quality", CultureInfo.CreateSpecificCulture("de")).GenerateSeoTitle(), StringComparison.OrdinalIgnoreCase)
                || values[parameterName].ToString().Equals(Resources.IMRResources.ResourceManager.GetString("Quality", CultureInfo.CreateSpecificCulture("vi")).GenerateSeoTitle(), StringComparison.OrdinalIgnoreCase);
        }
    } 
}
