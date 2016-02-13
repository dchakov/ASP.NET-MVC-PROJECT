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

        public IQueryable<City> GetAll()
        {
            return this.cities.All();
        }
    }
}