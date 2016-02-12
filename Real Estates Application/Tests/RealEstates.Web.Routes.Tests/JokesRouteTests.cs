namespace RealEstates.Web.Routes.Tests
{
    using Controllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MvcRouteTester;
    using System.Web.Routing;

    [TestClass]
    public class JokesRouteTests
    {
        [TestMethod]
        public void TestRouteById()
        {
            const string Url = "/RealEstate/OS4xMjMxMjMxMzEyMw==";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<HomeController>(c => c.ById("OS4xMjMxMjMxMzEyMw=="));
        }
    }
}
