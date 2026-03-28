using BikeRental.UserService.Domain.Entities;
using BikeRental.UserService.Domain.Entities.External;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BikeRental.UserService.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
