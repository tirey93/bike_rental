using BikeRental.BikeService.Contracts.Events;
using BikeRental.StationService.Domain.Entities.External;
using BikeRental.StationService.Domain.Repositories;
using Rebus.Handlers;

namespace BikeRental.StationService.Application.EventHandlers
{
    public class BikeUpdatedEventHandler : IHandleMessages<BikeUpdatedEvent>
    {
        private readonly IBikeRepository _bikeRepository;

        public BikeUpdatedEventHandler(IBikeRepository bikeRepository)
        {
            _bikeRepository = bikeRepository;
        }

        public async Task Handle(BikeUpdatedEvent message)
        {
            var bike = await _bikeRepository.Get(message.ExternalBikeId);
            if (bike == null)
            {
                await _bikeRepository.AddAsync(new Bike(message.ExternalBikeId)
                {
                    Model = message.Model,
                    Color = message.Color
                });
            }
            else
            {
                bike.Model = message.Model;
                bike.Color = message.Color;
            }
            await _bikeRepository.SaveChangesAsync();
        }
    }
}
