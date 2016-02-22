namespace RealEstates.Web
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "RealEstatePage",
                url: "RealEstate/{id}",
                defaults: new { controller = "RealEstate", action = "RealEstateById" });

            routes.MapRoute(
                name: "RealEstateAction",
                url: "RealEstate/{action}",
                defaults: new { controller = "RealEstate", action = "AddComment" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}