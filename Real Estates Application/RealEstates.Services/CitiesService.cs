namespace RealEstates.Services
{
    using Data.Repositories;
    using Model;
    using RealEstates.Services.Contracts;
    using System.Linq;

    public class CitiesService : ICitiesService
    {
        private IRepository<City> cities;

        public CitiesService(IRepository<City> cities)
        {
            this.cities = cities;
        }

        public void Add(City entity)
        {
            this.cities.Add(entity);
        }

        public void Delete(int id)
        {
            var entity = this.cities.GetById(id);
            this.cities.Delete(entity);
        }

        public void Dispose()
        {
            this.cities.Dispose();
        }

        public IQueryable<City> GetAll()
        {
            return this.cities.All();
        }

        public City GetById(int id)
        {
            return this.cities.All()
                .FirstOrDefault(c => c.Id == id);
        }

        public IQueryable<City> GetMostPopular()
        {
            return this.cities.All()
                .OrderByDescending(c => c.RealEstates.Count())
                .Take(20);
        }

        public void SaveChanges()
        {
            this.cities.SaveChanges();
        }
    }
}