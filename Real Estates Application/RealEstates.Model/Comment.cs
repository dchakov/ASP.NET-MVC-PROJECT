namespace RealEstates.Model
{
    using Common.Constants;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [MinLength(CommentConstants.ContentMinLength)]
        [MaxLength(CommentConstants.ContentMaxLength)]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public int RealEstateId { get; set; }

        public virtual RealEstate RealEstate { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}