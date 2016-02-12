namespace RealEstates.Data
{
    using RealEstates.Model;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IRealEstatesDbContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<Image> Images { get; set; }

        IDbSet<RealEstate> RealEstates { get; set; }

        IDbSet<Rating> Ratings { get; set; }

        IDbSet<City> Cities { get; set; }

        DbSet<TEntity> Set<TEntity>()
            where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : class;

        int SaveChanges();

        void Dispose();
    }
}
