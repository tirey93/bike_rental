using BikeRental.BikeAtStationService.Domain.Entities;

namespace BikeRental.BikeAtStationService.Domain.Repositories
{
    public interface IBikeAtStationRepository : IRepository<BikeAtStation>
    {
        Task AddBikeAtStation(BikeAtStation bikeAtStation);
        Task<IEnumerable<BikeAtStation>> GetAll();
        void RemoveBikeAtStation(BikeAtStation bikeAtStation);
    }
}
