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

        public ActionResult Search(
            int beds,
            string property_type,
            string minPrice,
            string maxPrice,
            string minYear,
            string maxYear,
            string minSQFT,
            string maxSQFT)
        {
            int minP = minPrice == string.Empty ? 0 : int.Parse(minPrice);
            int maxP = maxPrice == string.Empty ? int.MaxValue : int.Parse(maxPrice);
            int minY = minYear == string.Empty ? 1800 : int.Parse(minYear);
            int maxY = maxYear == string.Empty ? 2100 : int.Parse(maxYear);
            int minSQ = minSQFT == string.Empty ? 0 : int.Parse(minSQFT);
            int maxSQ = maxSQFT == string.Empty ? int.MaxValue : int.Parse(maxSQFT);

            IEnumerable<RealEstatesViewModel> realEstates =
               this.RealEstatesService.GetAll()
               .Where(r => r.Bedrooms >= beds &&
               (r.SellingPrice >= minP && r.SellingPrice <= maxP) &&
               (r.ConstructionYear >= minY && r.ConstructionYear <= maxY) &&
               (r.SquareMeter >= minSQ && r.SquareMeter <= maxSQ))
               .To<RealEstatesViewModel>().ToList();

            ForSellViewModel vm = new ForSellViewModel()
            {
                RealEstates = realEstates
            };

            return this.PartialView("_RealEstatesForSaleTemplate", vm);
        }
    }
}
