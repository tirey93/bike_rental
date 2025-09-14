using BikeRental.BikeService.Domain.Entities.External;
using BikeRental.BikeService.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BikeRental.BikeService.Infrastructure.Repositories
{
    public class BikeAtStationRepository : Repository<BikeAtStation>, IBikeAtStationRepository
    {
        public BikeAtStationRepository(AppDbContext appDbContext)
            : base(appDbContext, appDbContext.BikeAtStations)
        {
        }

        public async Task<bool> IsExists(Guid externalBikeId, Guid externalStationId)
        {
            return await _dbSet
                .Include(x => x.Bike)
                .AnyAsync(x => x.Bike.ExternalId == externalBikeId && x.StationExternalId == externalBikeId);
        }

        public async Task AddBikeAtStation(BikeAtStation bikeAtStation)
        {
            await _dbSet.AddAsync(bikeAtStation);

        }
    }
}
