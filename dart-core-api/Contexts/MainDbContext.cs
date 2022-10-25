using dart_core_api.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace dart_core_api.Contexts
{
    public class MainDbContext : DbContext
    {
        public static string RootDbDirectory = "Database\\Local\\";
        public static string DatabaseName = "dart-core-main.db";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string databaseDirectory = AppDomain.CurrentDomain.BaseDirectory + RootDbDirectory;
            Directory.CreateDirectory(databaseDirectory);
            
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = databaseDirectory + DatabaseName };
            var connectionString = connectionStringBuilder.ToString();

            var connection = new SqliteConnection(connectionString);

            optionsBuilder.UseSqlite(connection);
        }

        public DbSet<ProjectModel>? Project { get; set; }

    }
}
