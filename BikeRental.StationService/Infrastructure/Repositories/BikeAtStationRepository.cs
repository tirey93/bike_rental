using BikeRental.StationService.Domain.Entities;
using BikeRental.StationService.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;

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

    }
}
