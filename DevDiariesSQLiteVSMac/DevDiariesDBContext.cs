using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace DevDiariesSQLiteVSMac
{
    public class DevDiariesDBContext : DbContext
    {
        public DbSet<FirstEntity> FirstEntities { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder builder)
		{
			var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "DevDiaries.db" };
			var connectionString = connectionStringBuilder.ToString();
			var connection = new SqliteConnection(connectionString);

			builder.UseSqlite(connection);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            modelBuilder.Entity<FirstEntity>().HasKey(m => m.EntityId);
		}
    }
}
