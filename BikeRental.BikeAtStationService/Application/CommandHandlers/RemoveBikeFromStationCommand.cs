using BikeRental.BikeAtStationService.Domain.Repositories;
using MediatR;

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

        public RemoveBikeFromStationCommandHandler(IBikeAtStationRepository bikeAtStationRepository)
        {
            _bikeAtStationRepository = bikeAtStationRepository;
        }

        public async Task Handle(RemoveBikeFromStationCommand request, CancellationToken cancellationToken)
        {
            var bikeAtStation = await _bikeAtStationRepository.Get(request.ExternalBikeId, request.ExternalStationId);
            if (bikeAtStation != null)
            {
                _bikeAtStationRepository.RemoveBikeAtStation(bikeAtStation);
                await _bikeAtStationRepository.SaveChangesAsync();
            }
        }
    }
}
