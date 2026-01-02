using BikeRental.StationService.Application.Exceptions;
using BikeRental.StationService.Domain.Repositories;
using MediatR;

namespace BikeRental.StationService.Application.CommandHandlers.Station
{
    public class UpdateStationCommand : CreateStationCommand
    {
        public int Id { get; set; }
    }

    public class UpdateStationCommandHandler : IRequestHandler<UpdateStationCommand>
    {
        private readonly IStationRepository _stationRepository;

        public UpdateStationCommandHandler(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }

        public async Task Handle(UpdateStationCommand request, CancellationToken cancellationToken)
        {
            var station = _stationRepository.Get(request.Id)
                ?? throw new StationNotExistException(request.Id);

            station.Code = request.Code;
            station.Location = request.Location;
            station.Capacity = request.Capacity;

            await _stationRepository.SaveChangesAsync();
        }
    }
}
