namespace RealEstates.Services
{
    using System;
    using System.Linq;
    using Model;
    using RealEstates.Services.Contracts;
    using Data.Repositories;

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
