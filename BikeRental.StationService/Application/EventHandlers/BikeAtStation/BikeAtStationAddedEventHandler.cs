using BikeRental.BikeAtStationService.Contracts.Events;
using BikeRental.StationService.Domain.Repositories;
using Rebus.Handlers;

namespace BikeRental.StationService.Application.EventHandlers.BikeAtStation
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
            var bike = await _bikeRepository.Get(message.ExternalBikeId);
            var station = _stationRepository.Get(message.ExternalStationId);
            
            if (bike != null && station != null)
            {
                var exists = await _bikeAtStationRepository.Get(message.ExternalBikeId, message.ExternalStationId);
                if (exists == null)
                {
                    _bikeAtStationRepository.AddBikeToStation(new Domain.Entities.BikeAtStation(station, bike));
                    await _bikeAtStationRepository.SaveChangesAsync();
                }
            }
        }
    }
}
