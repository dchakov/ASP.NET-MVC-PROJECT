namespace RealEstates.Web.App_Start
{
    using System.Data.Entity;
    using Data;
    using Data.Migrations;

    public class DbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<RealEstatesDbContext, Configuration>());
            RealEstatesDbContext.Create().Database.Initialize(true);
        }
    }
}