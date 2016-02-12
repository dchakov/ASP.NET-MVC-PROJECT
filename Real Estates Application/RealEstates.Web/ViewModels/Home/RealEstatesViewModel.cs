namespace RealEstates.Web.ViewModels.Home
{
    using Infrastructure.Mapping;
    using Model;
    using Services.Web;
    using System;

    public class RealEstatesViewModel : IMapFrom<RealEstate>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public string Contact { get; set; }

        public int ConstructionYear { get; set; }

        public decimal? SellingPrice { get; set; }

        public decimal? RentingPrice { get; set; }

        public string Type { get; set; }

        public DateTime CreatedOn { get; set; }

        public int? Bedrooms { get; set; }

        public double SquareMeter { get; set; }

        public string UserId { get; set; }

        public string City { get; set; }

        public string ImageUrl { get; set; }

        public string Url
        {
            get
            {
                IIdentifierProvider identifier = new IdentifierProvider();
                return $"/RealEstate/{identifier.EncodeId(this.Id)}";
            }
        }
    }
}