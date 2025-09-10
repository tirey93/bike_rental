using BikeRental.StationService.Domain.Entities;
using BikeRental.StationService.Domain.Repositories;

namespace BikeRental.StationService.Infrastructure.Repositories
{
    public class BikeAtStationRepository : Repository<BikeAtStation>, IBikeAtStationRepository
    {
        public BikeAtStationRepository(AppDbContext appDbContext)
            : base(appDbContext, appDbContext.BikesAtStation)
        {
        }
    }
}
