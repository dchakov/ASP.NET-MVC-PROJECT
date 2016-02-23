namespace RealEstates.Services
{
    using System.Linq;
    using Data.Repositories;
    using RealEstates.Model;
    using RealEstates.Services.Contracts;

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
