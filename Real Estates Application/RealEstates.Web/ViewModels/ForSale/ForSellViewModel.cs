namespace RealEstates.Web.ViewModels.ForSale
{
    using System.Collections.Generic;
    using RealEstates.Web.ViewModels.Home;

    public class ForSellViewModel
    {
        public IEnumerable<RealEstatesViewModel> RealEstates { get; set; }
    }
}