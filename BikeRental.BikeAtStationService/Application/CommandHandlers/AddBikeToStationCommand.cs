using BikeRental.BikeAtStationService.Contracts.Events;
using BikeRental.BikeAtStationService.Domain.Entities;
using BikeRental.BikeAtStationService.Domain.Entities.External;
using BikeRental.BikeAtStationService.Domain.Repositories;
using MediatR;
using Rebus.Bus;

namespace BikeRental.BikeAtStationService.Application.CommandHandlers
{
    public class AddBikeToStationCommand : IRequest
    {
        public Guid ExternalBikeId { get; set; }
        public Guid ExternalStationId { get; set; }
    }

    public class AddBikeToStationCommandHandler : IRequestHandler<AddBikeToStationCommand>
    {
        private readonly IBikeAtStationRepository _bikeAtStationRepository;
        private readonly IBus _bus;

        public AddBikeToStationCommandHandler(IBikeAtStationRepository bikeAtStationRepository, IBus bus)
        {
            _bikeAtStationRepository = bikeAtStationRepository;
            _bus = bus;
        }

        public async Task Handle(AddBikeToStationCommand request, CancellationToken cancellationToken)
        {
            var bike = new Bike(request.ExternalBikeId);
            var station = new Station(request.ExternalStationId);

            await _bikeAtStationRepository.AddBikeAtStation(new BikeAtStation(bike, station));
            await _bikeAtStationRepository.SaveChangesAsync();

            await _bus.Publish(new BikeAtStationAddedEvent
            {
                ExternalBikeId = request.ExternalBikeId,
                ExternalStationId = request.ExternalStationId,
            });
        }
    }
}
