namespace RealEstates.Services.Contracts
{
    using RealEstates.Model;
    using System.Linq;

    public interface IImageService
    {
        IQueryable<Image> GetByRealEstateId(int realEstateId);

        int AddNew(Image image, int realEstateId);
    }
}
