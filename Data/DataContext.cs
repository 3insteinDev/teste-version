using Microsoft.EntityFrameworkCore;
using teste_version.Entities;

namespace teste_version.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> op) : base(op)
        {

        }

        public DbSet<VersionEntity> VersionEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Version.db", options => options.MigrationsAssembly(typeof(DataContext).Assembly.ToString()));
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
