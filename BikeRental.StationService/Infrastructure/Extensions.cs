using BikeRental.StationService.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using StationRental.StationService.Infrastructure.Repositories;

namespace BikeRental.StationService.Infrastructure
{
    public static class Extensions
    {
        public static void AddInfrastructure(this IServiceCollection services, string filename)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlite(filename));
            services.AddScoped<IStationRepository, StationRepository>();
        }
    }
}
