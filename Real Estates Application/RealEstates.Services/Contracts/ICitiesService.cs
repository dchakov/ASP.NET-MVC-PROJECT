namespace RealEstates.Services.Contracts
{
    using RealEstates.Model;
    using System.Linq;

    public interface ICitiesService
    {
        IQueryable<City> GetAll();

        IQueryable<City> GetMostPopular();

        void Add(City entity);

        void SaveChanges();

        City GetById(int id);

        void Delete(int id);

        void Dispose();
    }
}