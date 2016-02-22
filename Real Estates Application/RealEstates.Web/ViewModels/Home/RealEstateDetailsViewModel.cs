namespace RealEstates.Web.ViewModels.Home
{
    using RealEstates.Model;
    using Shared;
    using System.Collections.Generic;

    public class RealEstateDetailsViewModel
    {
        public RealEstateViewModel RealEstate { get; set; }

        public ICollection<Image> Images { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }

        public int CurrentCommentPage { get; set; }

        public int TotalCommentPages { get; set; }

        public int RealEstateId { get; set; }
    }
}
