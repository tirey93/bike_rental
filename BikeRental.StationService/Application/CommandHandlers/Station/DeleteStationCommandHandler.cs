using BikeRental.StationService.Application.Exceptions;
using BikeRental.StationService.Contracts.Events;
using BikeRental.StationService.Domain.Repositories;
using MediatR;
using Rebus.Bus;

namespace BikeRental.StationService.Application.CommandHandlers.Station
{
    public class DeleteStationCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteStationCommandHandler : IRequestHandler<DeleteStationCommand>
    {
        private readonly IStationRepository _stationRepository;
        private readonly IBikeAtStationRepository _bikeAtStationRepository;
        private readonly IBus _bus;

        public DeleteStationCommandHandler(IStationRepository stationRepository, IBikeAtStationRepository bikeAtStationRepository, IBus bus)
        {
            _stationRepository = stationRepository;
            _bikeAtStationRepository = bikeAtStationRepository;
            _bus = bus;
        }

        public async Task Handle(DeleteStationCommand request, CancellationToken cancellationToken)
        {
            var station = _stationRepository.Get(request.Id)
                ?? throw new StationNotExistException(request.Id);

            var bikesAtStation = _bikeAtStationRepository.GetByStation(station.Id);
            foreach (var bikeAtStation in bikesAtStation)
            {
                _bikeAtStationRepository.Remove(bikeAtStation);
            }
            await _bikeAtStationRepository.SaveChangesAsync();

            _stationRepository.Remove(station);
            await _stationRepository.SaveChangesAsync();

            await _bus.Publish(new StationRemovedEvent
            {
                ExternalStationId = station.ExternalId,
            });
        }
    }
}
