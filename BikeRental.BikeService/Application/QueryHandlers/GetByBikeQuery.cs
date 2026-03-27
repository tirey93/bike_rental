using BikeRental.BikeService.Domain.Repositories;
using BikeRental.BikeService.Responses;
using MediatR;

namespace BikeRental.BikeService.Application.QueryHandlers
{
    public class GetByBikeQuery : IRequest<BikeAtStationResponse>
    {
        public int BikeId { get; set; }
    }

    public class GetByBikeQueryHandler : IRequestHandler<GetByBikeQuery, BikeAtStationResponse>
    {
        private readonly IBikeAtStationRepository _bikeAtStationRepository;

        public GetByBikeQueryHandler(IBikeAtStationRepository bikeAtStationRepository)
        {
            _bikeAtStationRepository = bikeAtStationRepository;
        }

        public async Task<BikeAtStationResponse> Handle(GetByBikeQuery request, CancellationToken cancellationToken)
        {
            var bikeAtStation = await _bikeAtStationRepository.GetByBike(request.BikeId);
            if (bikeAtStation == null)
            {
                return null;
            }

            return new BikeAtStationResponse
            {
                Id = bikeAtStation.Id,
                StationId = bikeAtStation.StationId,
                Code = bikeAtStation.Station.Code,
                Location = bikeAtStation.Station.Location,
                Capacity = bikeAtStation.Station.Capacity
            };
        }
    }
}
