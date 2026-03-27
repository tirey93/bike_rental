using BikeRental.BikeAtStationService.Domain.Repositories;
using BikeRental.BikeAtStationService.Responses;
using MediatR;

namespace BikeRental.BikeAtStationService.Application.QueryHandlers
{
    public class GetAllBikeAtStationsQuery : IRequest<IEnumerable<BikeAtStationResponse>>
    {
    }

    public class GetAllBikeAtStationsQueryHandler : IRequestHandler<GetAllBikeAtStationsQuery, IEnumerable<BikeAtStationResponse>>
    {
        private readonly IBikeAtStationRepository _bikeAtStationRepository;

        public GetAllBikeAtStationsQueryHandler(IBikeAtStationRepository bikeAtStationRepository)
        {
            _bikeAtStationRepository = bikeAtStationRepository;
        }

        public async Task<IEnumerable<BikeAtStationResponse>> Handle(GetAllBikeAtStationsQuery request, CancellationToken cancellationToken)
        {
            var bikeAtStations = await _bikeAtStationRepository.GetAll();
            return bikeAtStations.Select(x => new BikeAtStationResponse
            {
                Id = x.Id,
                BikeExternalId = x.Bike.ExternalId,
                StationExternalId = x.Station.ExternalId
            });
        }
    }
}
