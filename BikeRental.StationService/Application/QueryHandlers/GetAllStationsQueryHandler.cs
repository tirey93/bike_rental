using BikeRental.StationService.Domain.Repositories;
using BikeRental.StationService.Responses;
using MediatR;

namespace BikeRental.StationService.Application.QueryHandlers
{
    public class GetAllStationsQuery : IRequest<IEnumerable<StationResponse>>
    {
    }

    public class GetAllStationsQueryHandler : IRequestHandler<GetAllStationsQuery, IEnumerable<StationResponse>>
    {
        private readonly IStationRepository _stationRepository;

        public GetAllStationsQueryHandler(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }

        public Task<IEnumerable<StationResponse>> Handle(GetAllStationsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_stationRepository.Get().Select(station =>
                new StationResponse
                {
                    Id = station.Id,
                    ExternalId = station.ExternalId,
                    Code = station.Code,
                    Capacity = station.Capacity,
                    Location = station.Location,
                    AvailableBikes = station.BikesAtStation.Count
                }));
        }
    }
}
