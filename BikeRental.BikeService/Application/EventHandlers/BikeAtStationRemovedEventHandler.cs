using BikeRental.BikeService.Domain.Repositories;
using BikeRental.StationService.Contracts.Events;
using Rebus.Handlers;

namespace BikeRental.BikeService.Application.EventHandlers
{
    public class BikeAtStationRemovedEventHandler : IHandleMessages<BikeAtStationRemovedEvent>
    {
        private readonly IBikeAtStationRepository _bikeAtStationRepository;
        private readonly IBikeRepository _bikeRepository;

        public BikeAtStationRemovedEventHandler(IBikeAtStationRepository bikeAtStationRepository, IBikeRepository bikeRepository)
        {
            _bikeAtStationRepository = bikeAtStationRepository;
            _bikeRepository = bikeRepository;
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
