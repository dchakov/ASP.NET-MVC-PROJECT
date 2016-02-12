namespace RealEstates.Web.ViewModels.UserM
{
    using Model;
    using System.Collections.Generic;

    public class UserPageViewModel
    {
        public string ImageURL { get; set; }

        public virtual ICollection<RealEstate> RealEstates { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }

        public RealEstate RealEstate { get; set; }
    }
}