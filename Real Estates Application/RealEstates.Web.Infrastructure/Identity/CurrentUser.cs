namespace RealEstates.Web.Infrastructure.Identity
{
    using System.Security.Principal;

    using Microsoft.AspNet.Identity;
    using RealEstates.Data;
    using RealEstates.Model;

    public class CurrentUser : ICurrentUser
    {
        private readonly IIdentity currentIdentity;
        private readonly IRealEstatesDbContext currentDbContext;

        private User user;

        public CurrentUser(IIdentity identity, IRealEstatesDbContext context)
        {
            this.currentIdentity = identity;
            this.currentDbContext = context;
        }

        public User Get()
        {
            return this.user ?? (this.user = this.currentDbContext.Users.Find(this.currentIdentity.GetUserId()));
        }
    }
}