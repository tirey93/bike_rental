using BikeRental.BikeAtStationService.Domain.Entities;
using BikeRental.BikeAtStationService.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BikeRental.BikeAtStationService.Infrastructure.Repositories
{
    public class BikeAtStationRepository : Repository<BikeAtStation>, IBikeAtStationRepository
    {
        public BikeAtStationRepository(AppDbContext appDbContext)
            : base(appDbContext, appDbContext.BikeAtStations)
        {
        }

        public async Task<BikeAtStation?> Get(Guid externalBikeId, Guid externalStationId)
        {
            return await _dbSet
                .Include(x => x.Bike)
                .Include(x => x.Station)
                .FirstOrDefaultAsync(x => x.Bike.ExternalId == externalBikeId && x.Station.ExternalId == externalStationId);
        }

        public async Task<IEnumerable<BikeAtStation>> GetAll()
        {
            return await _dbSet
                .Include(x => x.Bike)
                .Include(x => x.Station)
                .ToListAsync();
        }

        public async Task AddBikeAtStation(BikeAtStation bikeAtStation)
        {
            await _dbSet.AddAsync(bikeAtStation);
        }

        public void RemoveBikeAtStation(BikeAtStation bikeAtStation)
        {
            _dbSet.Remove(bikeAtStation);
        }
    }
}
