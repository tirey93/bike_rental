using BikeRental.BikeService.Domain.Repositories;
using BikeRental.StationService.Contracts.Events;
using Rebus.Handlers;

namespace BikeRental.BikeService.Application.EventHandlers
{
    public class StationRemovedEventHandler : IHandleMessages<StationRemovedEvent>
    {
        private readonly IStationRepository _stationRepository;
        private readonly IBikeAtStationRepository _bikeAtStationRepository;

        public StationRemovedEventHandler(IStationRepository stationRepository, IBikeAtStationRepository bikeAtStationRepository)
        {
            _stationRepository = stationRepository;
            _bikeAtStationRepository = bikeAtStationRepository;
        }
        public async Task Handle(StationRemovedEvent message)
        {
            var station = await _stationRepository.Get(message.ExternalStationId);
            if (station != null)
            {
                var bikesAtStation = _bikeAtStationRepository.GetByStation(station.Id);
                foreach (var bikeAtStation in bikesAtStation)
                {
                    _bikeAtStationRepository.Remove(bikeAtStation);
                }
                await _bikeAtStationRepository.SaveChangesAsync();

                _stationRepository.Remove(station);
                await _stationRepository.SaveChangesAsync();
            }
        }
    }
}
