using BikeRental.BikeAtStationService.Domain.Repositories;
using BikeRental.BikeService.Contracts.Events;
using Rebus.Handlers;

namespace BikeRental.BikeAtStationService.Application.EventHandlers.Bike
{
    public class BikeDeletedEventHandler : IHandleMessages<BikeDeletedEvent>
    {
        private readonly IBikeRepository _bikeRepository;

        public BikeDeletedEventHandler(IBikeRepository bikeRepository)
        {
            _bikeRepository = bikeRepository;
        }

        public async Task Handle(BikeDeletedEvent message)
        {
            var bike = await _bikeRepository.Get(message.ExternalBikeId);
            if (bike != null)
            {
                _bikeRepository.RemoveBike(bike);
                await _bikeRepository.SaveChangesAsync();
            }
        }
    }
}
