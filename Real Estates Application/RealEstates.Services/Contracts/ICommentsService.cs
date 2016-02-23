namespace RealEstates.Services.Contracts
{
    using System.Linq;
    using Model;

    public interface ICommentsService
    {
        IQueryable<Comment> GetAllByRealEstate(int realEstateId, int skip, int take);

        Comment GetById(int id);

        IQueryable<Comment> GetAllByUser(string username, int skip, int take);

        int AddNew(Comment comment, string userId);

        IQueryable<Comment> GetAll();

        void SaveChanges();

        void Delete(int id);

        void Dispose();

        IQueryable<Comment> GetCommentsForRealEstate(string id);

        Comment Create(string content, string authorEmail, string userId, int realEstateId);
    }
}