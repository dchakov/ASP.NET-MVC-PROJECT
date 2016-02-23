namespace RealEstates.Web.ViewModels.Home
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Infrastructure.Mapping;
    using Model;
    using Services.Web;

    public class RealEstateViewModel : IMapFrom<RealEstate>, IHaveCustomMappings
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

        public int? Bathrooms { get; set; }

        public double SquareMeter { get; set; }

        public string UserId { get; set; }

        public string BrokerName { get; set; }

        public string City { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<Image> Images { get; set; }

        public string Url
        {
            get
            {
                IIdentifierProvider identifier = new IdentifierProvider();
                return $"/RealEstate/{identifier.EncodeId(this.Id)}";
            }
        }

        public string FormattedCreatedOn
        {
            get
            {
                return this.CreatedOn.ToString("MMMM d, yyyy");
            }
        }

        public int CommentsCount { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<RealEstate, RealEstateViewModel>()
               .ForMember(x => x.City, opt => opt.MapFrom(x => x.City.Name));
            configuration.CreateMap<RealEstate, RealEstateViewModel>()
              .ForMember(x => x.Type, opt => opt.MapFrom(x => ((RealEstateType)x.Type).ToString()));
            configuration.CreateMap<RealEstate, RealEstateViewModel>()
             .ForMember(x => x.ImageUrl, opt => opt.MapFrom(x => x.Images.FirstOrDefault().ImageUrl));
            configuration.CreateMap<RealEstate, RealEstateViewModel>("CommentsCount")
               .ForMember(x => x.CommentsCount, opt => opt.MapFrom(x => x.Comments.Any() ? x.Comments.Count : 0));
            configuration.CreateMap<RealEstate, RealEstateViewModel>()
              .ForMember(x => x.BrokerName, opt => opt.MapFrom(x => x.User.Name));
        }
    }
}