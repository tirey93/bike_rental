using BikeRental.BikeAtStationService.Domain.Entities;

namespace BikeRental.BikeAtStationService.Domain.Repositories
{
    public interface IBikeAtStationRepository : IRepository<BikeAtStation>
    {
        Task AddBikeAtStation(BikeAtStation bikeAtStation);
        Task<BikeAtStation?> Get(Guid externalBikeId, Guid externalStationId);
        Task<IEnumerable<BikeAtStation>> GetAll();
        void RemoveBikeAtStation(BikeAtStation bikeAtStation);
    }
}
