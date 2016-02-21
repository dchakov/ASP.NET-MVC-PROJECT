namespace RealEstates.Services
{
    using Data.Repositories;
    using Model;
    using RealEstates.Services.Contracts;
    using System.Linq;
    using System;

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

        public IQueryable<City> GetMostPopular()
        {
            return this.cities.All()
                .OrderByDescending(c => c.RealEstates.Count())
                .Take(20);
        }
    }
}