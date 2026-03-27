using BikeRental.StationService.Domain.Entities;
using BikeRental.StationService.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BikeRental.StationService.Infrastructure.Repositories
{
    public class BikeAtStationRepository : Repository<BikeAtStation>, IBikeAtStationRepository
    {
        public BikeAtStationRepository(AppDbContext appDbContext)
            : base(appDbContext, appDbContext.BikesAtStation)
        {
        }

        public void AddBikeToStation(BikeAtStation bikeAtStation)
        {
            _dbSet.Add(bikeAtStation);
        }

        public BikeAtStation GetByBike(int id)
        {
            return _dbSet.Include(x => x.Station).FirstOrDefault(x => x.BikeId == id);
        }

        public IEnumerable<BikeAtStation> GetByStation(int id)
        {
            return _dbSet.Where(x => x.StationId == id);
        }

        public async Task<BikeAtStation> Get(Guid externalBikeId, Guid externalStationId)
        {
            return await _dbSet
                .Include(x => x.Bike)
                .Include(x => x.Station)
                .FirstOrDefaultAsync(x => x.Bike.ExternalId == externalBikeId && x.Station.ExternalId == externalStationId);
        }

        public void RemoveBikeAtStation(BikeAtStation bikeAtStation)
        {
            _dbSet.Remove(bikeAtStation);
        }

    }
}
