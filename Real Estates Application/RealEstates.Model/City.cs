namespace RealEstates.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class City
    {
        private ICollection<RealEstate> realEstates;

        public City()
        {
            this.realEstates = new HashSet<RealEstate>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<RealEstate> RealEstates
        {
            get { return this.realEstates; }
            set { this.realEstates = value; }
        }
    }
}