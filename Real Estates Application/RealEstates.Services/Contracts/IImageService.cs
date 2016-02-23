namespace RealEstates.Services.Contracts
{
    using System.Linq;
    using RealEstates.Model;

    public interface IImageService
    {
        IQueryable<Image> GetByRealEstateId(int realEstateId);

        int AddNew(Image image, int realEstateId);
    }
}