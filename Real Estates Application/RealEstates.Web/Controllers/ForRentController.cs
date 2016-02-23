namespace RealEstates.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using Ninject;
    using RealEstates.Model;
    using RealEstates.Services.Contracts;
    using RealEstates.Web.Infrastructure.Mapping;
    using RealEstates.Web.ViewModels.ForRent;
    using RealEstates.Web.ViewModels.Home;

    public class ForRentController : BaseController
    {
        private const int ItemsPerPage = 4;

        [Inject]
        public IRealEstatesService RealEstatesService { get; set; }

        public ActionResult Index(int id = 1)
        {
            ForRentViewModel viewModel;
            if (this.HttpContext.Cache["RealEstateForRent page_" + id] != null)
            {
                viewModel = (ForRentViewModel)this.HttpContext.Cache["RealEstateForRent page_" + id];
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
                    .To<RealEstateViewModel>().ToList();

                viewModel = new ForRentViewModel()
                {
                    CurrentPage = page,
                    TotalPages = totalPages,
                    RealEstates = realEstates
                };

                this.HttpContext.Cache["RealEstateForRent page_" + id] = viewModel;
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

            IEnumerable<RealEstateViewModel> realEstates =
               this.RealEstatesService.GetAll()
               .Where(r => r.Bedrooms >= beds &&
               (r.RentingPrice >= minP && r.RentingPrice <= maxP) &&
               (r.ConstructionYear >= minY && r.ConstructionYear <= maxY) &&
               (r.SquareMeter >= minSQ && r.SquareMeter <= maxSQ))
               .To<RealEstateViewModel>().ToList();

            ForRentViewModel vm = new ForRentViewModel()
            {
                RealEstates = realEstates
            };

            return this.PartialView("_RealEstatesForRentTemplate", vm);
        }
    }
}
