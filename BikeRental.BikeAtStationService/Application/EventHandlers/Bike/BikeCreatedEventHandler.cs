using BikeRental.BikeAtStationService.Domain.Entities.External;
using BikeRental.BikeAtStationService.Domain.Repositories;
using BikeRental.BikeService.Contracts.Events;
using Rebus.Handlers;

namespace BikeRental.BikeAtStationService.Application.EventHandlers.Bike
{
    public class BikeCreatedEventHandler : IHandleMessages<BikeCreatedEvent>
    {
        private readonly IBikeRepository _bikeRepository;

        public BikeCreatedEventHandler(IBikeRepository bikeRepository)
        {
            _bikeRepository = bikeRepository;
        }

        public async Task Handle(BikeCreatedEvent message)
        {
            var exists = await _bikeRepository.IsExists(message.ExternalBikeId);
            if (!exists)
            {
                await _bikeRepository.AddBike(new Domain.Entities.External.Bike(message.ExternalBikeId));
                await _bikeRepository.SaveChangesAsync();
            }
        }
    }
}
