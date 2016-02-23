namespace RealEstates.Web.Areas.Administration.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;
    using Infrastructure.Mapping;
    using Model;

    public class CommentAdminViewModel : IMapFrom<Comment>
    {
        [Key]
        public int Id { get; set; }

        [MinLength(CommentConstants.ContentMinLength, ErrorMessage = "Comment text shoud be more than 5 sybmols long.")]
        [MaxLength(CommentConstants.ContentMaxLength, ErrorMessage = "Comment text shoub be less than 2500 symbols long.")]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public int RealEstateId { get; set; }

        [Required]
        [RegularExpression(RealEstateConstants.EmailRegEx, ErrorMessage = "Invalid E-mail")]
        public string AuthorEmail { get; set; }
    }
}