namespace RealEstates.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using RealEstates.Model;
    using RealEstates.Data;
    using Ninject;
    using Services.Contracts;
    using Infrastructure.Mapping;
    using ViewModels;

    public class RealEstatesController : Controller
    {
        [Inject]
        public IRealEstatesService RealEstatesService { get; set; }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult RealEstates_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.RealEstatesService.GetAll()
                .To<RealEstateViewModel>()
                .ToDataSourceResult(request);

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult RealEstates_Update([DataSourceRequest]DataSourceRequest request, RealEstateViewModel realEstate)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.RealEstatesService.GetById(realEstate.Id);

                entity.Id = realEstate.Id;
                entity.Title = realEstate.Title;
                entity.Description = realEstate.Description;
                entity.Address = realEstate.Address;
                entity.Contact = realEstate.Contact;
                entity.ConstructionYear = realEstate.ConstructionYear;
                entity.SellingPrice = realEstate.SellingPrice;
                entity.RentingPrice = realEstate.RentingPrice;
                entity.Type = realEstate.Type;
                entity.Bedrooms = realEstate.Bedrooms;
                entity.Bathrooms = realEstate.Bathrooms;
                entity.SquareMeter = realEstate.SquareMeter;

                this.RealEstatesService.UpdateRealEstate(entity);
                this.RealEstatesService.SaveChanges();
            }

            var realEsateToDisplay = this.RealEstatesService.GetAll()
                .To<RealEstateViewModel>()
                .FirstOrDefault(x => x.Id == realEstate.Id);

            return this.Json(new[] { realEsateToDisplay }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult RealEstates_Destroy([DataSourceRequest]DataSourceRequest request, RealEstate realEstate)
        {
            this.RealEstatesService.Delete(realEstate.Id);
            this.RealEstatesService.SaveChanges();

            return this.Json(new[] { realEstate }.ToDataSourceResult(request, this.ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            this.RealEstatesService.Dispose();
            base.Dispose(disposing);
        }
    }
}
