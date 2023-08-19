using CititesManager.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CititesManager.Infrastructure.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public ApplicationDbContext()
        {

        }

        public virtual DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>()
                .HasData(new City() { CityId = Guid.NewGuid(), CityName = "Asuncion" });

            modelBuilder.Entity<City>()
                .HasData(new City() { CityId = Guid.NewGuid(), CityName = "New York" });
        }
    }
}
