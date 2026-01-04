using BikeRental.BikeService.Domain.Entities.External;
using BikeRental.BikeService.Domain.Repositories;
using BikeRental.StationService.Contracts.Events;
using Rebus.Handlers;

namespace BikeRental.BikeService.Application.EventHandlers.BikeAtStation
{
    public class BikeAtStationAddedEventHandler : IHandleMessages<BikeAtStationAddedEvent>
    {
        private readonly IBikeAtStationRepository _bikeAtStationRepository;
        private readonly IBikeRepository _bikeRepository;
        private readonly IStationRepository _stationRepository;

        public BikeAtStationAddedEventHandler(IBikeAtStationRepository bikeAtStationRepository, IBikeRepository bikeRepository, IStationRepository stationRepository)
        {
            _bikeAtStationRepository = bikeAtStationRepository;
            _bikeRepository = bikeRepository;
            _stationRepository = stationRepository;
        }
        public async Task Handle(BikeAtStationAddedEvent message)
        {
            var isExists = await _bikeAtStationRepository.IsExists(message.ExternalBikeId, message.ExternalStationId);
            var station = await _stationRepository.Get(message.ExternalStationId);
            if (!isExists && station != null)
            {
                var bike = await _bikeRepository.Get(message.ExternalBikeId);

                await _bikeAtStationRepository.AddBikeAtStation(new Domain.Entities.BikeAtStation(bike, station));
                await _bikeAtStationRepository.SaveChangesAsync();
            }
        }
    }
}
