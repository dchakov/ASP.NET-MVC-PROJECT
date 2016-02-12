namespace RealEstates.Services
{
    using Contracts;
    using Data.Repositories;
    using Model;
    using System;
    using System.Linq;

    public class CommentsService : ICommentsService
    {
        private readonly IRepository<Comment> comments;

        public CommentsService(IRepository<Comment> comments)
        {
            this.comments = comments;
        }

        public IQueryable<Comment> GetAllByRealEstate(int realEstateId, int skip, int take)
        {
            return this.comments
                .All()
                .Where(c => c.RealEstateId == realEstateId)
                .OrderBy(c => c.CreatedOn)
                .Skip(skip)
                .Take(take);
        }

        public IQueryable<Comment> GetById(int id)
        {
            return this.comments
                .All()
                .Where(c => c.Id == id);
        }

        public IQueryable<Comment> GetAllByUser(string username, int skip, int take)
        {
            return this.comments
                .All()
                .Where(c => c.User.UserName == username)
                .Skip(skip)
                .Take(take);
        }

        public int AddNew(Comment comment, string userId)
        {
            comment.CreatedOn = DateTime.Now;
            comment.UserId = userId;

            this.comments.Add(comment);
            this.comments.SaveChanges();

            return comment.Id;
        }
    }
}
