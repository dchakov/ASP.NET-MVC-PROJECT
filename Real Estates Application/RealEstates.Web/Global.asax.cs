namespace RealEstates.Web
{
    using System;
    using System.Reflection;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using RealEstates.Web.App_Start;
    using RealEstates.Web.Infrastructure.Mapping;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DbConfig.Initialize();

            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(Assembly.GetExecutingAssembly());
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = this.Server.GetLastError();
            this.Server.ClearError();
            this.Response.Redirect("/Home/Error");
        }
    }
}