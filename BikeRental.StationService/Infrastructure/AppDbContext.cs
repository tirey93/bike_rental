using BikeRental.StationService.Domain.Entities;
using BikeRental.StationService.Domain.Entities.External;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BikeRental.StationService.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Station> Stations { get; set; }
        public DbSet<BikeAtStation> BikesAtStation { get; set; }
        public DbSet<Bike> ExternalBikes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
