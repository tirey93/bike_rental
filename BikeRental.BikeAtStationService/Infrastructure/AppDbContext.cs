using BikeRental.BikeAtStationService.Domain.Entities;
using BikeRental.BikeAtStationService.Domain.Entities.External;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BikeRental.BikeAtStationService.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Bike> Bikes { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<BikeAtStation> BikeAtStations { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
