namespace RealEstates.Web.ViewModels.ForSale
{
    using System.Collections.Generic;
    using RealEstates.Web.ViewModels.Home;

    public class ForSellViewModel
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<RealEstatesViewModel> RealEstates { get; set; }
    }
}