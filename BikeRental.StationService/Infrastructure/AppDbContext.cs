using BikeRental.StationService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BikeRental.StationService.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Station> Stations { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
