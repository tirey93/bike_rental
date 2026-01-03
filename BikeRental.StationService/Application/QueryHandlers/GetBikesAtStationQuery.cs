using BikeRental.StationService.Application.Exceptions;
using BikeRental.StationService.Domain.Repositories;
using MediatR;

namespace BikeRental.StationService.Application.QueryHandlers
{
    public class GetBikesAtStationQuery : IRequest<IEnumerable<string>>
    {
        public int StationId { get; set; }
    }

    public class GetBikesAtStationQueryHandler : IRequestHandler<GetBikesAtStationQuery, IEnumerable<string>>
    {
        private readonly IStationRepository _stationRepository;

        public GetBikesAtStationQueryHandler(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }

        public Task<IEnumerable<string>> Handle(GetBikesAtStationQuery request, CancellationToken cancellationToken)
        {
            var station = _stationRepository.Get(request.StationId)
                ?? throw new StationNotExistException(request.StationId);

            var models = station.BikesAtStation.Select(x => x.Bike.Model);
            return Task.FromResult(models);
        }
    }
}
