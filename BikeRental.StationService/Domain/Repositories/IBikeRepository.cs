using BikeRental.StationService.Domain.Entities.External;

namespace BikeRental.StationService.Domain.Repositories
{
    public interface IBikeRepository : IRepository<Bike>
    {
        Task AddAsync(Bike bike);
        Task<Bike> Get(Guid externalId);
        Task<bool> IsExists(Guid externalId);
    }
}
