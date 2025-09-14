using BikeRental.BikeService.Domain.Entities.External;

namespace BikeRental.BikeService.Domain.Repositories
{
    public interface IBikeAtStationRepository : IRepository<BikeAtStation>
    {
        Task AddBikeAtStation(BikeAtStation bikeAtStation);
        Task<List<BikeAtStation>> Get();
        Task<BikeAtStation> Get(Guid externalBikeId, Guid externalStationId);
        Task<bool> IsExists(Guid externalBikeId, Guid externalStationId);
        void RemoveBikeAtStation(BikeAtStation bikeAtStation);
    }
}
