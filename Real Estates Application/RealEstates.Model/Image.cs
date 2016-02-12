namespace RealEstates.Model
{
    using System.ComponentModel.DataAnnotations;

    public class Image
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string FileName { get; set; }

        public string ImageUrl { get; set; }

        public int RealEstateId { get; set; }

        public virtual RealEstate RealEstate { get; set; }
    }
}
