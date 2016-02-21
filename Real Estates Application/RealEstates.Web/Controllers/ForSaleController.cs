namespace RealEstates.Web.Controllers
{
    using Infrastructure.Mapping;
    using Model;
    using Ninject;
    using RealEstates.Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using ViewModels.ForSale;
    using ViewModels.Home;

    public class ForSaleController : BaseController
    {
        private const int ItemsPerPage = 4;

        [Inject]
        public IRealEstatesService RealEstatesService { get; set; }

        public ActionResult Index(int id = 1)
        {
            ForSellViewModel viewModel;
            if (this.HttpContext.Cache["RealEstateForSale page_" + id] != null)
            {
                viewModel = (ForSellViewModel)this.HttpContext.Cache["RealEstateForSale page_" + id];
            }
            else
            {
                var page = id;
                var allItemsCount = this.RealEstatesService.GetForRent().Count();
                var totalPages = (int)Math.Ceiling(allItemsCount / (decimal)ItemsPerPage);
                var itemsToSkip = (page - 1) * ItemsPerPage;
                var realEstates = this.RealEstatesService.GetForRent()
                    .Skip(itemsToSkip)
                    .Take(ItemsPerPage)
                    .To<RealEstatesViewModel>().ToList();

                viewModel = new ForSellViewModel()
                {
                    CurrentPage = page,
                    TotalPages = totalPages,
                    RealEstates = realEstates
                };

                this.HttpContext.Cache["RealEstateForSale page_" + id] = viewModel;
            }

            return this.View(viewModel);
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
            int? beds,
            string property_type,
            string minPrice,
            string maxPrice,
            string minYear,
            string maxYear,
            string minSQFT,
            string maxSQFT)
        {
            if (beds == null)
            {
                beds = 0;
            }

            int minP = minPrice == string.Empty || minPrice == null ? 0 : int.Parse(minPrice);
            int maxP = maxPrice == string.Empty || maxPrice == null ? int.MaxValue : int.Parse(maxPrice);
            int minY = minYear == string.Empty || minYear == null ? 1800 : int.Parse(minYear);
            int maxY = maxYear == string.Empty || maxYear == null ? 2100 : int.Parse(maxYear);
            int minSQ = minSQFT == string.Empty || minSQFT == null ? 0 : int.Parse(minSQFT);
            int maxSQ = maxSQFT == string.Empty || maxSQFT == null ? int.MaxValue : int.Parse(maxSQFT);

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
