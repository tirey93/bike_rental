using BikeRental.StationService.Domain.Repositories;
using MediatR;

namespace BikeRental.StationService.Controllers.Commands
{
    public class AddBikeToStationCommand : IRequest
    {
        public int StationId { get; set; }

        public Guid ExternalBikeId { get; set; }
    }

    public class AddBikeToStationCommandHandler : IRequestHandler<AddBikeToStationCommand>
    {
        private readonly IStationRepository _stationRepository;

        public AddBikeToStationCommandHandler(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }

        public async Task Handle(AddBikeToStationCommand request, CancellationToken cancellationToken)
        {
            var station = _stationRepository.Get(request.StationId);
            station.AddBike(request.ExternalBikeId);

            //should check if exists in bike service

            await _stationRepository.SaveChangesAsync();
        }
    }
}
