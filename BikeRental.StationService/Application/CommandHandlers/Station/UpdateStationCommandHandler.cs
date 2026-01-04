using BikeRental.StationService.Application.Exceptions;
using BikeRental.StationService.Contracts.Events;
using BikeRental.StationService.Domain.Repositories;
using MediatR;
using Rebus.Bus;

namespace BikeRental.StationService.Application.CommandHandlers.Station
{
    public class UpdateStationCommand : CreateStationCommand
    {
        public int Id { get; set; }
    }

    public class UpdateStationCommandHandler : IRequestHandler<UpdateStationCommand>
    {
        private readonly IStationRepository _stationRepository;
        private readonly IBus _bus;

        public UpdateStationCommandHandler(IStationRepository stationRepository, IBus bus)
        {
            _stationRepository = stationRepository;
            _bus = bus;
        }

        public async Task Handle(UpdateStationCommand request, CancellationToken cancellationToken)
        {
            var station = _stationRepository.Get(request.Id)
                ?? throw new StationNotExistException(request.Id);

            station.Code = request.Code;
            station.Location = request.Location;
            station.Capacity = request.Capacity;

            await _stationRepository.SaveChangesAsync();

            await _bus.Publish(new StationUpdatedEvent
            {
                ExternalStationId = station.ExternalId,
                Location = request.Location,
                Code = request.Code,
                Capacity = request.Capacity,
            });
        }
    }
}
