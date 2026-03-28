using BikeRental.BikeAtStationService.Domain.Entities.External;
using BikeRental.BikeAtStationService.Domain.Repositories;
using BikeRental.StationService.Contracts.Events;
using Rebus.Handlers;

namespace BikeRental.BikeAtStationService.Application.EventHandlers.Station
{
    public class StationCreatedEventHandler : IHandleMessages<StationCreatedEvent>
    {
        private readonly IStationRepository _stationRepository;

        public StationCreatedEventHandler(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }

        public async Task Handle(StationCreatedEvent message)
        {
            var exists = await _stationRepository.IsExists(message.ExternalStationId);
            if (!exists)
            {
                await _stationRepository.AddStation(new Domain.Entities.External.Station(message.ExternalStationId));
                await _stationRepository.SaveChangesAsync();
            }
        }
    }
}
