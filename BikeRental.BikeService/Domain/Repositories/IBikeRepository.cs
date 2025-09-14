using BikeRental.BikeService.Domain.Entities;

namespace BikeRental.BikeService.Domain.Repositories
{
    public interface IBikeRepository : IRepository<Bike>
    {
        Task AddBike(Bike bike);
        IEnumerable<Bike> Get();
        Task<Bike> Get(Guid externalId);
    }
}
