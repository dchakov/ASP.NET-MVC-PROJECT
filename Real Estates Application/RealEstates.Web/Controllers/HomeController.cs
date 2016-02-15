namespace RealEstates.Web.Controllers
{
    using Infrastructure.Mapping;
    using Model;
    using Ninject;
    using Services.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using ViewModels.Home;
    using ViewModels.UserM;

    public class HomeController : BaseController
    {
        [Inject]
        public IUsersService UsersService { get; set; }

        [Inject]
        public ICitiesService CitiesService { get; set; }

        [Inject]
        public IRealEstatesService RealEstatesService { get; set; }

        public ActionResult Index()
        {
            IEnumerable<CityViewModel> cities = this.Cache.Get(
                "cities",
                () => this.CitiesService.GetAll()
                .OrderBy(x => x.Name)
                .To<CityViewModel>().ToList(), 15 * 60);

            IEnumerable<UserViewModel> users = this.UsersService.GetAll()
                .Where(u => u.UserName != "admin@site.com")
                .OrderBy(u => u.UserName)
                .To<UserViewModel>().ToList();

            IEnumerable<RealEstatesViewModel> realEstates =
                this.RealEstatesService.GetAll()
                .To<RealEstatesViewModel>().ToList();

            HomePageViewModel vm = new HomePageViewModel()
            {
                Cities = cities,
                Users = users,
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

        public ActionResult RealEstatesByCity(string name)
        {
            IEnumerable<RealEstatesViewModel> realEstates =
                this.RealEstatesService.GetByCity(name)
                .To<RealEstatesViewModel>().ToList();

            return this.View(realEstates);
        }

        public ActionResult ForSale()
        {
            return this.View();
        }

        public ActionResult ForRent()
        {
            return this.View();
        }
    }
}