using BikeRental.StationService.Domain.Repositories;
using BikeRental.StationService.Responses;
using MediatR;

namespace BikeRental.StationService.Controllers.Queries
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
            return Task.FromResult(_stationRepository.Get().Select(bike =>
                new StationResponse
                {
                    Id = bike.Id,
                    ExternalId = bike.ExternalId,
                    Code = bike.Code,
                    Capacity = bike.Capacity,
                    Location = bike.Location
                }));
        }
    }
}
