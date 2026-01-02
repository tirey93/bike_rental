using BikeRental.StationService.Application.Exceptions;
using BikeRental.StationService.Domain.Repositories;
using MediatR;

namespace BikeRental.StationService.Application.CommandHandlers.Station
{
    public class DeleteStationCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteStationCommandHandler : IRequestHandler<DeleteStationCommand>
    {
        private readonly IStationRepository _stationRepository;

        public DeleteStationCommandHandler(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }

        public async Task Handle(DeleteStationCommand request, CancellationToken cancellationToken)
        {
            var station = _stationRepository.Get(request.Id)
                ?? throw new StationNotExistException(request.Id);

            _stationRepository.Remove(station);
            await _stationRepository.SaveChangesAsync();
        }
    }
}
