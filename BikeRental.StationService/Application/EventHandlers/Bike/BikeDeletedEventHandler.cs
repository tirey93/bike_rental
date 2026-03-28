using BikeRental.BikeService.Contracts.Events;
using BikeRental.StationService.Domain.Entities.External;
using BikeRental.StationService.Domain.Repositories;
using Rebus.Handlers;

namespace BikeRental.StationService.Application.EventHandlers.Bike
{
    public class BikeDeletedEventHandler : IHandleMessages<BikeDeletedEvent>
    {
        private readonly IBikeRepository _bikeRepository;
        private readonly IBikeAtStationRepository _bikeAtStationRepository;

        public BikeDeletedEventHandler(IBikeRepository bikeRepository, IBikeAtStationRepository bikeAtStationRepository)
        {
            _bikeRepository = bikeRepository;
            _bikeAtStationRepository = bikeAtStationRepository;
        }

        public async Task Handle(BikeDeletedEvent message)
        {
            var bike = await _bikeRepository.Get(message.ExternalBikeId);
            if (bike != null)
            {
                var bikeAtStation = _bikeAtStationRepository.GetByBike(bike.Id);
                if (bikeAtStation != null)
                {
                    _bikeAtStationRepository.Remove(bikeAtStation);
                    await _bikeAtStationRepository.SaveChangesAsync();
                }
                _bikeRepository.Remove(bike);
                await _bikeRepository.SaveChangesAsync();
            }
        }
    }
}
