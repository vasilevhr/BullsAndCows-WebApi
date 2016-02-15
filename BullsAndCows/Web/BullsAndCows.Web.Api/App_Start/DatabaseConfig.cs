namespace BullsAndCows.Web.Api.App_Start
{
    using Data.Migrations;
    using System.Data.Entity;

    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BullsAndCows.Data.BullsAndCowsDbContext, Configuration>());
        }
    }
}