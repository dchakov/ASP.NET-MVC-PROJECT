namespace RealEstates.Web.Controllers.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Model;
    using Moq;
    using RealEstates.Web.Infrastructure.Mapping;
    using Services.Contracts;
    using ViewModels.Home;

    [TestClass]
    public class HomeControllerTests
    {
        // [TestMethod]
        // public void ByIdShouldWorkCorrectly()
        // {
        //    var autoMapperConfig = new AutoMapperConfig();
        //    autoMapperConfig.Execute(typeof(RealEstateController).Assembly);
        //    const string RealEstateTitle = "SomeTitle";
        //    var realEstateServiceMock = new Mock<IRealEstatesService>();
        //    realEstateServiceMock.Setup(x => x.GetByEncodedId(It.IsAny<string>()))
        //        .Returns(new RealEstate
        //        {
        //            Id = 1,
        //            Title = RealEstateTitle,
        //            Description = "asghftrjryjry",
        //            Address = "asrhsthsry",
        //            Contact = "asrhsthsry",
        //            ConstructionYear = 2000,
        //            CreatedOn = DateTime.Now,
        //            Bedrooms = 2,
        //            SquareMeter = 232
        //        });

        // var controller = new RealEstateController();

        // var result = controller.RealEstateById("some") as ViewResult;
        //    var model = result.Model as RealEstate;

        // Assert.IsNotNull(result);
        //    Assert.AreEqual(2, model.Bedrooms);
        // }
        [TestMethod]
        public void TestHomeControllerIndex()
        {
            HomeController obj = new HomeController();
            var actResult = obj.Error() as ViewResult;
            Assert.IsNotNull(actResult);
        }

        // [TestMethod]
        // public void TestHomeControllerRealEstatesByCity()
        // {
        //    var listReal = new List<RealEstateViewModel>();
        //    listReal.Add(new RealEstateViewModel()
        //    {
        //        Title = "SomeTitle",
        //        Description = "asghftrjryjry",
        //        Address = "asrhsthsry",
        //        Contact = "asrhsthsry",
        //        ConstructionYear = 2000,
        //        CreatedOn = DateTime.Now,
        //        Bedrooms = 2,
        //        SquareMeter = 232,
        //        City = "Atlanta"
        //    });
        //    listReal.Add(new RealEstateViewModel()
        //    {
        //        Title = "SomeTitle",
        //        Description = "asghftrjryjry",
        //        Address = "asrhsthsry",
        //        Contact = "asrhsthsry",
        //        ConstructionYear = 2000,
        //        CreatedOn = DateTime.Now,
        //        Bedrooms = 2,
        //        SquareMeter = 232,
        //        City = "Miami"
        //    });

        // var raelRepository = new Mock<IRealEstatesService>();
        //    raelRepository.Setup(e => e.GetAll().To<RealEstateViewModel>().ToList()).Returns(listReal);
        //    var controller = new HomeController();

        // var result = controller.RealEstatesByCity("Miami") as ViewResult;
        //    var model = result.Model as RealEstateViewModel;

        // // Assert.IsNotNull(result);
        // }
    }
}