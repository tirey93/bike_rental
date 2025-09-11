using BikeRental.StationService.Domain.Repositories;
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

        public RemoveBikeToStationCommandHandler(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }

        public async Task Handle(RemoveBikeToStationCommand request, CancellationToken cancellationToken)
        {
            var station = _stationRepository.Get(request.StationId);
            station.RemoveBike(request.ExternalBikeId);

            //should check if exists in bike service

            await _stationRepository.SaveChangesAsync();
        }
    }
}
