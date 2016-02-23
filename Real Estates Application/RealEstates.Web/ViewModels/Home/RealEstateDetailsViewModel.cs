namespace RealEstates.Web.ViewModels.Home
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;
    using RealEstates.Model;
    using Shared;

    public class RealEstateDetailsViewModel
    {
        public RealEstateViewModel RealEstate { get; set; }

        public ICollection<Image> Images { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }

        public int CurrentCommentPage { get; set; }

        public int TotalCommentPages { get; set; }

        public int RealEstateId { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [MinLength(RealEstateConstants.CommentTextMinLenght, ErrorMessage = "Comment text shoud be more than 5 sybmols long.")]
        [MaxLength(RealEstateConstants.CommentTextMaxLenght, ErrorMessage = "Comment text shoub be less than 2500 symbols long.")]
        public string Content { get; set; }

        [Required]
        [Display(Name = "Email")]
        [RegularExpression(RealEstateConstants.EmailRegEx, ErrorMessage = "Invalid E-mail")]
        public string AuthorEmail { get; set; }
    }
}
