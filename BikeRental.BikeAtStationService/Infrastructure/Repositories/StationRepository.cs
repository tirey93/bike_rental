using BikeRental.BikeAtStationService.Domain.Entities.External;
using BikeRental.BikeAtStationService.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BikeRental.BikeAtStationService.Infrastructure.Repositories
{
    public class StationRepository : Repository<Station>, IStationRepository
    {
        public StationRepository(AppDbContext appDbContext)
            : base(appDbContext, appDbContext.Stations)
        {
        }

        public async Task AddStation(Station station)
        {
            await _dbSet.AddAsync(station);
        }

        public async Task<Station> Get(Guid externalId)
        {
            return await _dbSet.FirstOrDefaultAsync(s => s.ExternalId == externalId);
        }

        public async Task<bool> IsExists(Guid externalId)
        {
            return await _dbSet.AnyAsync(s => s.ExternalId == externalId);
        }

        public void RemoveStation(Station station)
        {
            _dbSet.Remove(station);
        }
    }
}
