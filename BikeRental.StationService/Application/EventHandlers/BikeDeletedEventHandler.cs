using BikeRental.BikeService.Contracts.Events;
using BikeRental.StationService.Domain.Entities.External;
using BikeRental.StationService.Domain.Repositories;
using Rebus.Handlers;

namespace BikeRental.StationService.Application.EventHandlers
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
                _bikeRepository.Remove(bike);
                await _bikeRepository.SaveChangesAsync();
            }
        }
    }
}
