using BikeRental.BikeService.Domain.Entities.External;

namespace BikeRental.BikeService.Domain.Repositories
{
    public interface IBikeAtStationRepository : IRepository<BikeAtStation>
    {
        Task AddBikeAtStation(BikeAtStation bikeAtStation);
        Task<bool> IsExists(Guid externalBikeId, Guid externalStationId);
    }
}
