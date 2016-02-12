namespace RealEstates.Web.ViewModels.Home
{
    using RealEstates.Model;
    using RealEstates.Web.Infrastructure.Mapping;

    public class CityViewModel : IMapFrom<City>
    {
        public string Name { get; set; }
    }
}