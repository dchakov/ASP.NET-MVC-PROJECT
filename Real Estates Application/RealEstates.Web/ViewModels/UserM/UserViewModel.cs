namespace RealEstates.Web.ViewModels.UserM
{
    using RealEstates.Model;
    using RealEstates.Web.Infrastructure.Mapping;

    public class UserViewModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string ImageUrl { get; set; }
    }
}