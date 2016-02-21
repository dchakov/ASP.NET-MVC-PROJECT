﻿namespace RealEstates.Web.Infrastructure.Filters
{
    using System.Web.Mvc;

    public class ApplicationVersionHeaderFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Headers.Add("Application", "RealEsate");
            base.OnActionExecuted(filterContext);
        }
    }
}
