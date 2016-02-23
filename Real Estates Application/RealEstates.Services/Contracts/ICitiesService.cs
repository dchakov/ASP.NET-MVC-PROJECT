namespace RealEstates.Services.Contracts
{
    using System.Linq;
    using RealEstates.Model;

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