using BikeRental.BikeService.Domain.Entities.External;
using BikeRental.BikeService.Domain.Repositories;
using BikeRental.StationService.Contracts.Events;
using Rebus.Handlers;

namespace BikeRental.BikeService.Application.EventHandlers.Station
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
            var isExists = await _stationRepository.IsExists(message.ExternalStationId);
            if (!isExists)
            {
                await _stationRepository.AddAsync(new Domain.Entities.External.Station(message.ExternalStationId)
                {
                    Location = message.Location,
                    Code = message.Code,
                    Capacity = message.Capacity,
                });
                await _stationRepository.SaveChangesAsync();
            }
        }
    }
}
