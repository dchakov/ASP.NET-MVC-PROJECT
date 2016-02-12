namespace RealEstates.Web.App_Start
{
    using Data;
    using Data.Migrations;
    using System.Data.Entity;

    public class DbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<RealEstatesDbContext, Configuration>());
            RealEstatesDbContext.Create().Database.Initialize(true);
        }
    }
}