using BikeRental.StationService.Application.Exceptions;
using BikeRental.StationService.Domain.Repositories;
using BikeRental.StationService.Responses;
using MediatR;

namespace BikeRental.StationService.Application.QueryHandlers
{
    public class GetBikesAtStationQuery : IRequest<IEnumerable<BikeResponse>>
    {
        public int StationId { get; set; }
    }

    public class GetBikesAtStationQueryHandler : IRequestHandler<GetBikesAtStationQuery, IEnumerable<BikeResponse>>
    {
        private readonly IStationRepository _stationRepository;

        public GetBikesAtStationQueryHandler(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }

        public Task<IEnumerable<BikeResponse>> Handle(GetBikesAtStationQuery request, CancellationToken cancellationToken)
        {
            var station = _stationRepository.Get(request.StationId)
                ?? throw new StationNotExistException(request.StationId);

            var bikes = station.BikesAtStation.Select(x => new BikeResponse
            {
                Color = x.Bike.Color,
                Model = x.Bike.Model,
            });
            return Task.FromResult(bikes);
        }
    }
}
