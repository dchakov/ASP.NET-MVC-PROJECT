namespace RealEstates.Services.Contracts
{
    using RealEstates.Model;
    using System.Linq;

    public interface ICitiesService
    {
        IQueryable<City> GetAll();
    }
}
