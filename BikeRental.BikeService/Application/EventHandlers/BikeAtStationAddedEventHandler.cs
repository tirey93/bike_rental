using BikeRental.BikeService.Domain.Entities.External;
using BikeRental.BikeService.Domain.Repositories;
using BikeRental.StationService.Contracts.Events;
using Rebus.Handlers;

namespace BikeRental.BikeService.Application.EventHandlers
{
    public class BikeAtStationAddedEventHandler : IHandleMessages<BikeAtStationAddedEvent>
    {
        private readonly IBikeAtStationRepository _bikeAtStationRepository;
        private readonly IBikeRepository _bikeRepository;

        public BikeAtStationAddedEventHandler(IBikeAtStationRepository bikeAtStationRepository, IBikeRepository bikeRepository)
        {
            _bikeAtStationRepository = bikeAtStationRepository;
            _bikeRepository = bikeRepository;
        }
        public async Task Handle(BikeAtStationAddedEvent message)
        {
            var isExists = await _bikeAtStationRepository.IsExists(message.ExternalBikeId, message.ExternalStationId);
            if (!isExists)
            {
                var bike = await _bikeRepository.Get(message.ExternalBikeId);
                await _bikeAtStationRepository.AddBikeAtStation(new BikeAtStation(bike, message.ExternalStationId));
                //await _bikeAtStationRepository.SaveChangesAsync();
            }
        }
    }
}
