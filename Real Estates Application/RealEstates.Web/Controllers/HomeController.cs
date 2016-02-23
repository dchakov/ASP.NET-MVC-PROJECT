namespace RealEstates.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Ninject;
    using Services.Contracts;
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
                () => this.CitiesService.GetMostPopular()
                .To<CityViewModel>()
                .ToList(),
                15 * 60);

            IEnumerable<UserViewModel> users = this.UsersService.GetMostPopularAgents()
                .To<UserViewModel>().ToList();

            IEnumerable<RealEstateViewModel> realEstates =
                this.RealEstatesService.GetMostRecent()
                .To<RealEstateViewModel>().ToList();

            HomePageViewModel vm = new HomePageViewModel()
            {
                Cities = cities,
                Users = users,
                RealEstates = realEstates
            };

            return this.View(vm);
        }

        public ActionResult RealEstatesByCity(string name)
        {
            IEnumerable<RealEstateViewModel> realEstates =
                this.RealEstatesService.GetByCity(name)
                .To<RealEstateViewModel>().ToList();

            return this.View(realEstates);
        }

        public ActionResult Error()
        {
            return this.View();
        }
    }
}