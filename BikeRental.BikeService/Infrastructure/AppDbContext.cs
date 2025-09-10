using BikeRental.BikeService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BikeRental.BikeService.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Bike> Bikes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
