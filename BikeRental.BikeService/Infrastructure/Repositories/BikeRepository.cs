using BikeRental.BikeService.Domain.Entities;
using BikeRental.BikeService.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BikeRental.BikeService.Infrastructure.Repositories
{
    public class BikeRepository : Repository<Bike>, IBikeRepository
    {
        public BikeRepository(AppDbContext appDbContext)
            : base(appDbContext, appDbContext.Bikes)
        {
        }

        public async Task AddBike(Bike bike)
        {
            await _dbSet.AddAsync(bike);
        }

        public IEnumerable<Bike> Get()
        {
            return _dbSet;
        }
    }
}
