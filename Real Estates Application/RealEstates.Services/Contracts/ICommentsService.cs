namespace RealEstates.Services.Contracts
{
    using Model;
    using System.Linq;

    public interface ICommentsService
    {
        IQueryable<Comment> GetAllByRealEstate(int realEstateId, int skip, int take);

        IQueryable<Comment> GetById(int id);

        IQueryable<Comment> GetAllByUser(string username, int skip, int take);

        int AddNew(Comment comment, string userId);
    }
}
