using BikeRental.BikeAtStationService.Contracts.Events;
using BikeRental.StationService.Domain.Repositories;
using Rebus.Handlers;

namespace BikeRental.StationService.Application.EventHandlers.BikeAtStation
{
    public class BikeAtStationRemovedEventHandler : IHandleMessages<BikeAtStationRemovedEvent>
    {
        private readonly IBikeAtStationRepository _bikeAtStationRepository;

        public BikeAtStationRemovedEventHandler(IBikeAtStationRepository bikeAtStationRepository)
        {
            _bikeAtStationRepository = bikeAtStationRepository;
        }

        public async Task Handle(BikeAtStationRemovedEvent message)
        {
            var bikeAtStation = await _bikeAtStationRepository.Get(message.ExternalBikeId, message.ExternalStationId);
            if (bikeAtStation != null)
            {
                _bikeAtStationRepository.RemoveBikeAtStation(bikeAtStation);
                await _bikeAtStationRepository.SaveChangesAsync();
            }
        }
    }
}
