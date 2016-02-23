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
            routeCollection.ShouldMap(Url).To<RealEstateController>(c => c.RealEstateById("OS4xMjMxMjMxMzEyMw=="));
        }

        [TestMethod]
        public void TestRouteByAction()
        {
            const string Url = "/RealEstate/AddComment";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<RealEstateController>(c => c.RealEstateById(string.Empty));
        }

        [TestMethod]
        public void TestRouteByActionAndId()
        {
            const string Url = "/Home/RealEstatesByCity?name=Atlanta";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<HomeController>(c => c.RealEstatesByCity("Atlanta"));
        }

        [TestMethod]
        public void TestRouteByUserId()
        {
            const string Url = "/UserProfile/Index/d5e09fe1-1894-4c91-8990-6a12fd65261e";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<UserProfileController>(c => c.Index("d5e09fe1-1894-4c91-8990-6a12fd65261e"));
        }
    }
}