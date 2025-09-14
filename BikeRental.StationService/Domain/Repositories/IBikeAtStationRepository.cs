using BikeRental.StationService.Domain.Entities;

namespace BikeRental.StationService.Domain.Repositories
{
    public interface IBikeAtStationRepository : IRepository<BikeAtStation>
    {
        void AddBikeToStation(BikeAtStation bikeAtStation);
    }
}
