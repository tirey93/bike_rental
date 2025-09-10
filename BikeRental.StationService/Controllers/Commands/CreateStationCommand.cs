using BikeRental.StationService.Domain.Entities;
using BikeRental.StationService.Domain.Repositories;
using MediatR;

namespace BikeRental.StationService.Controllers.Commands
{
    public class CreateStationCommand : IRequest
    {
        public string Code { get; set; }

        public string Location { get; set; }

        public int Capacity { get; set; }
    }

    public class CreateStationCommandHandler : IRequestHandler<CreateStationCommand>
    {
        private readonly IStationRepository _stationRepository;

        public CreateStationCommandHandler(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }

        public async Task Handle(CreateStationCommand request, CancellationToken cancellationToken)
        {
            await _stationRepository.AddStation(new Station
            {
                Code = request.Code,
                Location = request.Location,
                Capacity = request.Capacity,
            });

            await _stationRepository.SaveChangesAsync();
        }
    }
}
