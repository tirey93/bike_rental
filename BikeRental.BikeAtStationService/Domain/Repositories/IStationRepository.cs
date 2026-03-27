using BikeRental.BikeAtStationService.Domain.Entities.External;

namespace BikeRental.BikeAtStationService.Domain.Repositories
{
    public interface IStationRepository : IRepository<Station>
    {
        Task AddStation(Station station);
        Task<Station> Get(Guid externalId);
        Task<bool> IsExists(Guid externalId);
        void RemoveStation(Station station);
    }
}
