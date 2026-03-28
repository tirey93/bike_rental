using BikeRental.BikeService.Domain.Entities.External;
using BikeRental.BikeService.Domain.Repositories;
using BikeRental.StationService.Contracts.Events;
using Rebus.Handlers;

namespace BikeRental.BikeService.Application.EventHandlers.Station
{
    public class StationUpdatedEventHandler : IHandleMessages<StationUpdatedEvent>
    {
        private readonly IStationRepository _stationRepository;

        public StationUpdatedEventHandler(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }
        public async Task Handle(StationUpdatedEvent message)
        {
            var station = await _stationRepository.Get(message.ExternalStationId);
            if (station == null)
            {
                await _stationRepository.AddAsync(new Domain.Entities.External.Station(message.ExternalStationId)
                {
                    Location = message.Location,
                    Code = message.Code,
                    Capacity = message.Capacity,
                });
            }
            else
            {
                station.Location = message.Location;
                station.Code = message.Code;
                station.Capacity = message.Capacity;
            }
            await _stationRepository.SaveChangesAsync();
        }
    }
}
