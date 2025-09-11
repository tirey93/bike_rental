using BikeRental.BikeService.Contracts.Events;
using BikeRental.StationService.Domain.Entities.External;
using BikeRental.StationService.Domain.Repositories;
using Rebus.Handlers;

namespace BikeRental.StationService.Application.EventHandlers
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
                await _bikeRepository.AddAsync(new Bike(message.ExternalBikeId));
                await _bikeRepository.SaveChangesAsync();
            }
        }
    }
}
