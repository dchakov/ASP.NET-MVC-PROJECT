namespace RealEstates.Services.Contracts
{
    using System.Linq;
    using RealEstates.Model;

    public interface IUsersService
    {
        IQueryable<User> GetByUserName(string username);

        IQueryable<User> GetAll();

        void Rate(Rating rating);

        User GetByUserId(string id);

        IQueryable<User> GetMostPopularAgents();

        void SaveChanges();

        void Update(User user);

        void Delete(string id);

        void Dispose();
    }
}