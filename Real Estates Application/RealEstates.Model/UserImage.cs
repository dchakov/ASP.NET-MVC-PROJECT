namespace RealEstates.Model
{
    using System.ComponentModel.DataAnnotations;

    public class UserImage
    {
        [Key]
        public int ImageId { get; set; }

        [Required]
        public byte[] Content { get; set; }

        [Required]
        public string FileExtension { get; set; }
    }
}
