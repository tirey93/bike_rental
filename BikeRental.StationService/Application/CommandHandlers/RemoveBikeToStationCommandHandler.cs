using BikeRental.StationService.Application.Exceptions;
using BikeRental.StationService.Domain.Repositories;
using BikeRental.StationService.Infrastructure.Repositories;
using MediatR;

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

        public RemoveBikeToStationCommandHandler(IStationRepository stationRepository, IBikeRepository bikeRepository)
        {
            _stationRepository = stationRepository;
            _bikeRepository = bikeRepository;
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

            await _stationRepository.SaveChangesAsync();
        }
    }
}
