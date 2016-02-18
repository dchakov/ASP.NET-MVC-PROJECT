namespace RealEstates.Web.Controllers
{
    using Infrastructure.Mapping;
    using Model;
    using Ninject;
    using RealEstates.Services.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using ViewModels.ForSale;
    using ViewModels.Home;

    public class ForSaleController : Controller
    {
        [Inject]
        public IRealEstatesService RealEstatesService { get; set; }

        public ActionResult Index()
        {
            IEnumerable<RealEstatesViewModel> realEstates =
                this.RealEstatesService.GetAll()
                .OrderBy(r => r.CreatedOn)
                .To<RealEstatesViewModel>().ToList();

            ForSellViewModel vm = new ForSellViewModel()
            {
                RealEstates = realEstates
            };

            return this.View(vm);
        }

        public ActionResult RealEstateById(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            RealEstate realEstate = this.RealEstatesService.GetByEncodedId(id);
            if (realEstate == null)
            {
                return this.HttpNotFound();
            }

            return this.View(realEstate);
        }
    }
}
