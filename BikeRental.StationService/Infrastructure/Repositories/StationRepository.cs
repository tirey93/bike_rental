using BikeRental.StationService.Domain.Entities;
using BikeRental.StationService.Domain.Repositories;
using BikeRental.StationService.Infrastructure;

namespace StationRental.StationService.Infrastructure.Repositories
{
    public class StationRepository : Repository<Station>, IStationRepository
    {
        public StationRepository(AppDbContext appDbContext)
            : base(appDbContext, appDbContext.Stations)
        {
        }

        public async Task AddStation(Station Station)
        {
            await _dbSet.AddAsync(Station);
        }

        public IEnumerable<Station> Get()
        {
            return _dbSet;
        }
    }
}
