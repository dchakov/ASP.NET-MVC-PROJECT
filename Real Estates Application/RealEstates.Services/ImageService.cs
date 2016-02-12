namespace RealEstates.Services
{
    using Data.Repositories;
    using RealEstates.Model;
    using RealEstates.Services.Contracts;
    using System.Linq;

    public class ImageService : IImageService
    {
        private readonly IRepository<Image> images;

        public ImageService(IRepository<Image> images)
        {
            this.images = images;
        }

        public int AddNew(Image image, int realEstateId)
        {
            image.RealEstateId = realEstateId;

            this.images.Add(image);
            this.images.SaveChanges();

            return image.Id;
        }

        public IQueryable<Image> GetByRealEstateId(int realEstateId)
        {
            return this.images.All()
                .Where(i => i.RealEstateId == realEstateId);
        }
    }
}
