namespace RealEstates.Web
{
    using RealEstates.Web.Infrastructure.Filters;
    using System.Web.Mvc;

    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ApplicationVersionHeaderFilter());
        }
    }
}