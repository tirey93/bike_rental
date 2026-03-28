using BikeRental.UserService.Domain.Repositories;
using BikeRental.UserService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BikeRental.UserService.Infrastructure
{
    public static class Extensions
    {
        public static void AddInfrastructure(this IServiceCollection services, string filename)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlite(filename));
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
