using BikeRental.StationService.Domain.Entities;

namespace BikeRental.StationService.Domain.Repositories
{
    public interface IStationRepository : IRepository<Station>
    {
        Task AddStation(Station station);
        IEnumerable<Station> Get();
        Station Get(int id);
    }
}
