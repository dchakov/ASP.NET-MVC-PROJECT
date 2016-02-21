namespace RealEstates.Web.ViewModels.UserM
{
    using Model;
    using System.Collections.Generic;

    public class UserPageViewModel
    {
        public string ImageURL { get; set; }

        public ICollection<RealEstate> RealEstates { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Rating> Ratings { get; set; }

        public RealEstate RealEstate { get; set; }
    }
}