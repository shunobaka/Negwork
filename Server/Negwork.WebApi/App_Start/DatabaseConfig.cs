namespace Negwork.WebApi
{
    using Data;
    using Data.Migrations;
    using System.Data.Entity;

    public class DatabaseConfig
    {
        public static void Configure()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NegworkDbContext, Configuration>());
        }
    }
}