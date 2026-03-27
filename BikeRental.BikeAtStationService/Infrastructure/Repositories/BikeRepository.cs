using BikeRental.BikeAtStationService.Domain.Entities.External;
using BikeRental.BikeAtStationService.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BikeRental.BikeAtStationService.Infrastructure.Repositories
{
    public class BikeRepository : Repository<Bike>, IBikeRepository
    {
        public BikeRepository(AppDbContext appDbContext)
            : base(appDbContext, appDbContext.Bikes)
        {
        }

        public async Task AddBike(Bike bike)
        {
            await _dbSet.AddAsync(bike);
        }

        public async Task<Bike> Get(Guid externalId)
        {
            return await _dbSet.FirstOrDefaultAsync(b => b.ExternalId == externalId);
        }

        public async Task<bool> IsExists(Guid externalId)
        {
            return await _dbSet.AnyAsync(b => b.ExternalId == externalId);
        }

        public void RemoveBike(Bike bike)
        {
            _dbSet.Remove(bike);
        }
    }
}
