namespace RealEstates.Web.ViewModels.Home
{
    using System.Collections.Generic;
    using RealEstates.Web.ViewModels.UserM;

    public class HomePageViewModel
    {
        public IEnumerable<UserViewModel> Users { get; set; }

        public IEnumerable<CityViewModel> Cities { get; set; }

        public IEnumerable<RealEstateViewModel> RealEstates { get; set; }
    }
}