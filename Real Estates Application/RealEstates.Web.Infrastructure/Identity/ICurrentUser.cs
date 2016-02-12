namespace RealEstates.Web.Infrastructure.Identity
{
    using RealEstates.Model;

    public interface ICurrentUser
    {
        User Get();
    }
}
