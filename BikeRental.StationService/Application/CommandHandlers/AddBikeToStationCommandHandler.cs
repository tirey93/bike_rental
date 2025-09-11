using BikeRental.StationService.Application.Exceptions;
using BikeRental.StationService.Domain.Repositories;
using MediatR;

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

        public AddBikeToStationCommandHandler(IStationRepository stationRepository, IBikeRepository bikeRepository)
        {
            _stationRepository = stationRepository;
            _bikeRepository = bikeRepository;
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

            await _stationRepository.SaveChangesAsync();
        }
    }
}
