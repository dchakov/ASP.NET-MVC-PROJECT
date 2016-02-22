namespace RealEstates.Services.Contracts
{
    using RealEstates.Model;
    using System.Linq;

    public interface IUsersService
    {
        IQueryable<User> GetByUserName(string username);

        IQueryable<User> GetAll();

        void Rate(Rating rating);

        User GetByUserId(string id);

        IQueryable<User> GetMostPopularAgents();

        void SaveChanges();

        void Update(User user);
    }
}