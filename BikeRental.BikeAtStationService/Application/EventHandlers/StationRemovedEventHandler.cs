using BikeRental.BikeAtStationService.Domain.Repositories;
using BikeRental.StationService.Contracts.Events;
using Rebus.Handlers;

namespace BikeRental.BikeAtStationService.Application.EventHandlers
{
    public class StationRemovedEventHandler : IHandleMessages<StationRemovedEvent>
    {
        private readonly IStationRepository _stationRepository;

        public StationRemovedEventHandler(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }

        public async Task Handle(StationRemovedEvent message)
        {
            var station = await _stationRepository.Get(message.ExternalStationId);
            if (station != null)
            {
                _stationRepository.RemoveStation(station);
                await _stationRepository.SaveChangesAsync();
            }
        }
    }
}
