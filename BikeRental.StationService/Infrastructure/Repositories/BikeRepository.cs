using BikeRental.StationService.Domain.Entities.External;
using BikeRental.StationService.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BikeRental.StationService.Infrastructure.Repositories
{
    public class BikeRepository : Repository<Bike>, IBikeRepository
    {
        public BikeRepository(AppDbContext appDbContext)
            : base(appDbContext, appDbContext.ExternalBikes)
        {
        }

        public async Task<bool> IsExists(Guid externalId)
        {
            return await _dbSet.AnyAsync(x => x.ExternalId == externalId);
        }

        public async Task AddAsync(Bike bike)
        {
            await _dbSet.AddAsync(bike);
        }
    }
}
