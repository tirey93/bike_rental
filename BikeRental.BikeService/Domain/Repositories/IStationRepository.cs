using BikeRental.BikeService.Domain.Entities.External;

namespace BikeRental.BikeService.Domain.Repositories
{
    public interface IStationRepository : IRepository<Station>
    {
        Task AddAsync(Station station);
        Task<Station> Get(Guid externalId);
        Task<bool> IsExists(Guid externalId);
    }
}
