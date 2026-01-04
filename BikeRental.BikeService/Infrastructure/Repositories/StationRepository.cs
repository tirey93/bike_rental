using BikeRental.BikeService.Domain.Entities.External;
using BikeRental.BikeService.Domain.Repositories;
using BikeRental.BikeService.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace StationRental.StationService.Infrastructure.Repositories
{
    public class StationRepository : Repository<Station>, IStationRepository
    {
        public StationRepository(AppDbContext appDbContext)
            : base(appDbContext, appDbContext.Stations)
        {
        }

        public async Task<bool> IsExists(Guid externalId)
        {
            return await _dbSet.AnyAsync(x => x.ExternalId == externalId);
        }

        public async Task AddAsync(Station station)
        {
            await _dbSet.AddAsync(station);
        }

        public async Task<Station> Get(Guid externalId)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.ExternalId == externalId);
        }
    }
}
