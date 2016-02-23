namespace RealEstates.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [MinLength(CommentConstants.ContentMinLength, ErrorMessage = "Comment text shoud be more than 5 sybmols long.")]
        [MaxLength(CommentConstants.ContentMaxLength, ErrorMessage = "Comment text shoub be less than 2500 symbols long.")]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public int RealEstateId { get; set; }

        public virtual RealEstate RealEstate { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        [RegularExpression(RealEstateConstants.EmailRegEx, ErrorMessage = "Invalid E-mail")]
        public string AuthorEmail { get; set; }
    }
}