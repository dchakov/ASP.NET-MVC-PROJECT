namespace RealEstates.Web.ViewModels.UserM
{
    using System.Collections.Generic;
    using Model;

    public class UserPageViewModel
    {
        public string ImageURL { get; set; }

        public ICollection<RealEstate> RealEstates { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Rating> Ratings { get; set; }

        public RealEstate RealEstate { get; set; }
    }
}