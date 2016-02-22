namespace RealEstates.Services
{
    using RealEstates.Services.Contracts;
    using System.Linq;
    using RealEstates.Model;
    using Data.Repositories;
    using System;

    public class UsersImageService : IUsersImageService
    {
        private readonly IRepository<UserImage> images;

        public UsersImageService(IRepository<UserImage> images)
        {
            this.images = images;
        }

        public UserImage GetById(int? userImageId)
        {
            return this.images.All().FirstOrDefault(i => i.ImageId == userImageId);
        }

        public void SaveChanges()
        {
           this.images.SaveChanges();
        }
    }
}
