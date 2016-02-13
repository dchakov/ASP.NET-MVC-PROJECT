namespace RealEstates.Web.Controllers.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Model;
    using Moq;
    using RealEstates.Web.Infrastructure.Mapping;
    using Services.Contracts;

    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void ByIdShouldWorkCorrectly()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(HomeController).Assembly);
            const string RealEstateTitle = "SomeTitle";
            var realEstateServiceMock = new Mock<IRealEstatesService>();
            realEstateServiceMock.Setup(x => x.GetByEncodedId(It.IsAny<string>()))
                .Returns(new RealEstate
                {
                    Title = RealEstateTitle,
                    Description = "asghftrjryjry",
                    Address = "asrhsthsry",
                    Contact = "asrhsthsry",
                    ConstructionYear = 2000,
                    CreatedOn = DateTime.Now,
                    Bedrooms = 2,
                    SquareMeter = 232
                });

            // var controller = new HomeController();
            // controller.WithCallTo(x => x.ById("adfahgsth"))
            //    .ShouldRenderView("ById")
            //    .WithModel<RealEstate>(
            //        viewModel =>
            //        {
            //            Assert.AreEqual(RealEstateTitle, viewModel.Title);
            //        }).AndNoModelErrors();
        }
    }
}