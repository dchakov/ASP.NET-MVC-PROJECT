namespace RealEstates.Services.Contracts
{
    using RealEstates.Model;

    public interface IUsersImageService
    {
        UserImage GetById(int? userImageId);

        void SaveChanges();
    }
}
