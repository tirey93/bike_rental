using BikeRental.BikeService.Contracts.Events;
using BikeRental.StationService.Contracts.Events;
using BikeRental.StationService.Domain.Entities.External;
using BikeRental.StationService.Domain.Repositories;
using MediatR;
using Rebus.Bus;

namespace BikeRental.StationService.Application.CommandHandlers.Station
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
        private readonly IBus _bus;

        public CreateStationCommandHandler(IStationRepository stationRepository, IBus bus)
        {
            _stationRepository = stationRepository;
            this._bus = bus;
        }

        public async Task Handle(CreateStationCommand request, CancellationToken cancellationToken)
        {
            var station = new Domain.Entities.Station
            {
                Code = request.Code,
                Location = request.Location,
                Capacity = request.Capacity,
            };
            await _stationRepository.AddStation(station);

            await _stationRepository.SaveChangesAsync();

            await _bus.Publish(new StationCreatedEvent
            {
                ExternalStationId = station.ExternalId,
            });
        }
    }
}
