using BikeRental.BikeService.Domain.Entities;
using BikeRental.BikeService.Domain.Entities.External;

namespace BikeRental.BikeService.Domain.Repositories
{
    public interface IBikeAtStationRepository : IRepository<BikeAtStation>
    {
        Task AddBikeAtStation(BikeAtStation bikeAtStation);
        Task<BikeAtStation> Get(Guid externalBikeId, Guid externalStationId);
        IEnumerable<BikeAtStation> GetByStation(int id);
        Task<bool> IsExists(Guid externalBikeId, Guid externalStationId);
        void RemoveBikeAtStation(BikeAtStation bikeAtStation);
    }
}
