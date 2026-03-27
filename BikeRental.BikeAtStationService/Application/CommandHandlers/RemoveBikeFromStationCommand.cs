using BikeRental.BikeAtStationService.Contracts.Events;
using BikeRental.BikeAtStationService.Domain.Exceptions;
using BikeRental.BikeAtStationService.Domain.Repositories;
using MediatR;
using Rebus.Bus;

namespace BikeRental.BikeAtStationService.Application.CommandHandlers
{
    public class RemoveBikeFromStationCommand : IRequest
    {
        public Guid ExternalBikeId { get; set; }
        public Guid ExternalStationId { get; set; }
    }

    public class RemoveBikeFromStationCommandHandler : IRequestHandler<RemoveBikeFromStationCommand>
    {
        private readonly IBikeAtStationRepository _bikeAtStationRepository;
        private readonly IBus _bus;

        public RemoveBikeFromStationCommandHandler(IBikeAtStationRepository bikeAtStationRepository, IBus bus)
        {
            _bikeAtStationRepository = bikeAtStationRepository;
            _bus = bus;
        }

        public async Task Handle(RemoveBikeFromStationCommand request, CancellationToken cancellationToken)
        {
            var bikeAtStation = await _bikeAtStationRepository.Get(request.ExternalBikeId, request.ExternalStationId);
            if (bikeAtStation == null)
            {
                throw new BikeNotExistsAtStationException(request.ExternalBikeId, request.ExternalStationId);
            }

            _bikeAtStationRepository.RemoveBikeAtStation(bikeAtStation);
            await _bikeAtStationRepository.SaveChangesAsync();

            await _bus.Publish(new BikeAtStationRemovedEvent
            {
                ExternalBikeId = request.ExternalBikeId,
                ExternalStationId = request.ExternalStationId,
            });
        }
    }
}
