namespace RealEstates.Services.Contracts
{
    using RealEstates.Model;
    using System.Linq;

    public interface IRealEstatesService
    {
        IQueryable<RealEstate> GetAll();

        RealEstate GetById(int? id);

        int AddNew(RealEstate newRealEstate, string userId);

        RealEstate GetByEncodedId(string id);

        IQueryable<RealEstate> GetByCity(string name);

        int SaveChanges();

        void UpdateRealEstate(RealEstate realEsate);

        void Delete(int id);

        IQueryable<RealEstate> GetMostRecent();

        IQueryable<RealEstate> GetForSale();

        IQueryable<RealEstate> GetForRent();

        void Dispose();
    }
}