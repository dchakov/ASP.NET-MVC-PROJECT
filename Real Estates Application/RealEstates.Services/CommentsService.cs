namespace RealEstates.Services
{
    using Contracts;
    using Data.Repositories;
    using Model;
    using System;
    using System.Linq;
    using Web;
    public class CommentsService : ICommentsService
    {
        private readonly IRepository<Comment> comments;
        private readonly IIdentifierProvider identifierProvider;

        public CommentsService(IRepository<Comment> comments, IIdentifierProvider identifierProvider)
        {
            this.comments = comments;
            this.identifierProvider = identifierProvider;
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

        public Comment GetById(int id)
        {
            return this.comments
                .All()
                .FirstOrDefault(c => c.Id == id);
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

        public IQueryable<Comment> GetAll()
        {
            return this.comments.All();
        }

        public void SaveChanges()
        {
            this.comments.SaveChanges();
        }

        public void Delete(int id)
        {
            var comment = this.comments.GetById(id);
            this.comments.Delete(comment);
        }

        public void Dispose()
        {
            this.comments.Dispose();
        }

        public IQueryable<Comment> GetCommentsForRealEstate(string id)
        {
            var intId = this.identifierProvider.DecodeId(id);
            var comments = this.comments
                .All()
                .OrderByDescending(c => c.CreatedOn)
                .Where(c => c.RealEstateId == intId);
            return comments;
        }

        public Comment Create(string content, string authorEmail, string userId, int realEstateId)
        {
            var comment = new Comment()
            {
                Content = content,
                RealEstateId = realEstateId,
                CreatedOn = DateTime.Now,
                AuthorEmail = authorEmail,
                UserId = userId
            };

            this.comments.Add(comment);
            this.comments.SaveChanges();

            return comment;
        }
    }
}