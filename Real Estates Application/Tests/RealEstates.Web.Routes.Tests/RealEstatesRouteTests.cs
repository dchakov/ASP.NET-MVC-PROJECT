namespace RealEstates.Web.Routes.Tests
{
    using System.Web.Routing;
    using Controllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MvcRouteTester;

    [TestClass]
    public class RealEstatesRouteTests
    {
        [TestMethod]
        public void TestRouteById()
        {
            const string Url = "/RealEstate/OS4xMjMxMjMxMzEyMw==";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<HomeController>(c => c.RealEstateById("OS4xMjMxMjMxMzEyMw=="));
        }
    }
}