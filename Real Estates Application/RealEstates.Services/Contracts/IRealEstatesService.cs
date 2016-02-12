namespace RealEstates.Services.Contracts
{
    using RealEstates.Model;
    using System.Linq;

    public interface IRealEstatesService
    {
        IQueryable<RealEstate> GetAll(int skip, int take);

        IQueryable<RealEstate> GetById(int id);

        int AddNew(RealEstate newRealEstate, string userId);

        RealEstate GetByEncodedId(string id);
    }
}
