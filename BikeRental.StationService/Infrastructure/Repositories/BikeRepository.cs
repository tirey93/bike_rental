using BikeRental.StationService.Domain.Entities.External;
using BikeRental.StationService.Domain.Repositories;

namespace BikeRental.StationService.Infrastructure.Repositories
{
    public class BikeRepository : Repository<Bike>, IBikeRepository
    {
        public BikeRepository(AppDbContext appDbContext)
            : base(appDbContext, appDbContext.ExternalBikes)
        {
        }
    }
}
