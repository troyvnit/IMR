using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace IMR.Controllers.Attributes
{
    public class LocalizationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var defaultCulture = "en";
            var culture = filterContext.RouteData.Values["culture"];
            if (culture != null && !string.IsNullOrWhiteSpace(culture.ToString()))
            {
                defaultCulture = culture.ToString();
            }
            else
            {
                filterContext.RouteData.Values["culture"] = defaultCulture;
            }
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(defaultCulture);
            base.OnActionExecuting(filterContext);
        }
    }
}