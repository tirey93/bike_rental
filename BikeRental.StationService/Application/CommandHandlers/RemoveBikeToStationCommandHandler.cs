using BikeRental.StationService.Application.Exceptions;
using BikeRental.StationService.Contracts.Events;
using BikeRental.StationService.Domain.Repositories;
using MediatR;
using Rebus.Bus;

namespace BikeRental.StationService.Application.CommandHandlers
{
    public class RemoveBikeToStationCommand : IRequest
    {
        public int StationId { get; set; }

        public Guid ExternalBikeId { get; set; }
    }

    public class RemoveBikeToStationCommandHandler : IRequestHandler<RemoveBikeToStationCommand>
    {
        private readonly IStationRepository _stationRepository;
        private readonly IBikeRepository _bikeRepository;
        private readonly IBus _bus;
        private readonly IBikeAtStationRepository _bikeAtStationRepository;

        public RemoveBikeToStationCommandHandler(IStationRepository stationRepository, IBikeRepository bikeRepository, IBus bus, IBikeAtStationRepository bikeAtStationRepository)
        {
            _stationRepository = stationRepository;
            _bikeRepository = bikeRepository;
            _bus = bus;
            _bikeAtStationRepository = bikeAtStationRepository;
        }

        public async Task Handle(RemoveBikeToStationCommand request, CancellationToken cancellationToken)
        {
            var bike = await _bikeRepository.Get(request.ExternalBikeId);
            if (bike == null)
            {
                throw new BikeNotExistsException(request.ExternalBikeId);
            }
            var station = _stationRepository.Get(request.StationId);
            station.RemoveBike(request.ExternalBikeId);
            await _bus.Publish(new BikeAtStationRemovedEvent
            {
                ExternalBikeId = request.ExternalBikeId,
                ExternalStationId = station.ExternalId,
            });
            //await _stationRepository.SaveChangesAsync();
        }
    }
}
