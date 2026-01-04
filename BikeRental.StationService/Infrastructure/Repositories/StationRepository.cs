using BikeRental.StationService.Domain.Entities;
using BikeRental.StationService.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BikeRental.StationService.Infrastructure.Repositories
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
            return _dbSet.Include(x => x.BikesAtStation);
        }

        public Station Get(int id)
        {
            return _dbSet
                .Include(x => x.BikesAtStation).ThenInclude(x => x.Bike)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
