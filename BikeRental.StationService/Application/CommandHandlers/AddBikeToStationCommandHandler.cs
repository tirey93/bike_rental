using BikeRental.BikeService.Contracts.Events;
using BikeRental.StationService.Application.Exceptions;
using BikeRental.StationService.Contracts.Events;
using BikeRental.StationService.Domain.Entities.External;
using BikeRental.StationService.Domain.Repositories;
using MediatR;
using Rebus.Bus;

namespace BikeRental.StationService.Application.CommandHandlers
{
    public class AddBikeToStationCommand : IRequest
    {
        public int StationId { get; set; }

        public Guid ExternalBikeId { get; set; }
    }

    public class AddBikeToStationCommandHandler : IRequestHandler<AddBikeToStationCommand>
    {
        private readonly IStationRepository _stationRepository;
        private readonly IBikeRepository _bikeRepository;
        private readonly IBus _bus;

        public AddBikeToStationCommandHandler(IStationRepository stationRepository, IBikeRepository bikeRepository, IBus bus)
        {
            _stationRepository = stationRepository;
            _bikeRepository = bikeRepository;
            _bus = bus;
        }

        public async Task Handle(AddBikeToStationCommand request, CancellationToken cancellationToken)
        {
            var bike = await _bikeRepository.Get(request.ExternalBikeId);
            if (bike == null)
            {
                throw new BikeNotExistsException(request.ExternalBikeId);
            }

            var station = _stationRepository.Get(request.StationId);
            station.AddBike(request.ExternalBikeId);

            await _bus.Publish(new BikeAtStationAddedEvent
            {
                ExternalBikeId = request.ExternalBikeId,
                ExternalStationId = station.ExternalId,
            });
            await _stationRepository.SaveChangesAsync();
        }
    }
}
