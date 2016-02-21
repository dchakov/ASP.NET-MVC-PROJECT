namespace RealEstates.Web.Areas.Administration.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Common.Constants;
    using Infrastructure.Mapping;
    using Model;

    public class RealEstateViewModel : IMapFrom<RealEstate>, IHaveCustomMappings
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(RealEstateConstants.TitleMinLength)]
        [MaxLength(RealEstateConstants.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(RealEstateConstants.DescriptionMinLength)]
        [MaxLength(RealEstateConstants.DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Contact { get; set; }

        [Range(RealEstateConstants.MinConstructionYear, int.MaxValue)]
        public int ConstructionYear { get; set; }

        public decimal? SellingPrice { get; set; }

        public decimal? RentingPrice { get; set; }

        public RealEstateType Type { get; set; }

        public DateTime CreatedOn { get; set; }

        public int? Bedrooms { get; set; }

        public int? Bathrooms { get; set; }

        public double SquareMeter { get; set; }

        public string AgentName { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<RealEstate, RealEstateViewModel>()
                .ForMember(x => x.AgentName, opt => opt.MapFrom(x => x.User.Name));
        }
    }
}