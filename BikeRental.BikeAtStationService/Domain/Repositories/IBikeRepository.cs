using BikeRental.BikeAtStationService.Domain.Entities.External;

namespace BikeRental.BikeAtStationService.Domain.Repositories
{
    public interface IBikeRepository : IRepository<Bike>
    {
        Task AddBike(Bike bike);
        Task<Bike> Get(Guid externalId);
        Task<bool> IsExists(Guid externalId);
        void RemoveBike(Bike bike);
    }
}
