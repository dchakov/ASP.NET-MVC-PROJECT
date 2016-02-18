namespace RealEstates.Web.ViewModels.ForRent
{
    using System.Collections.Generic;
    using RealEstates.Web.ViewModels.Home;

    public class ForRentViewModel
    {
        public IEnumerable<RealEstatesViewModel> RealEstates { get; set; }
    }
}