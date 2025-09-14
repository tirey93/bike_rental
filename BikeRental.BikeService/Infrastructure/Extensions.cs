using BikeRental.BikeService.Domain.Repositories;
using BikeRental.BikeService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BikeRental.BikeService.Infrastructure
{
    public static class Extensions
    {
        public static void AddInfrastructure(this IServiceCollection services, string filename)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlite(filename));
            services.AddScoped<IBikeRepository, BikeRepository>();
            services.AddScoped<IBikeAtStationRepository, BikeAtStationRepository>();
        }
    }
}
