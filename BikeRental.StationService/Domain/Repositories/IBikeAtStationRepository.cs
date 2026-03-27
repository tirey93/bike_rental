using BikeRental.StationService.Domain.Entities;

namespace BikeRental.StationService.Domain.Repositories
{
    public interface IBikeAtStationRepository : IRepository<BikeAtStation>
    {
        void AddBikeToStation(BikeAtStation bikeAtStation);
        BikeAtStation GetByBike(int id);
        IEnumerable<BikeAtStation> GetByStation(int id);
        Task<BikeAtStation> Get(Guid externalBikeId, Guid externalStationId);
        void RemoveBikeAtStation(BikeAtStation bikeAtStation);
    }
}
