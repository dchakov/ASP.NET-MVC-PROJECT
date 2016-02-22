namespace RealEstates.Web.ViewModels.ForRent
{
    using System.Collections.Generic;
    using RealEstates.Web.ViewModels.Home;

    public class ForRentViewModel
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<RealEstateViewModel> RealEstates { get; set; }
    }
}