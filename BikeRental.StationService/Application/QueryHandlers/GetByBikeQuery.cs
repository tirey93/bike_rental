using BikeRental.StationService.Application.Exceptions;
using BikeRental.StationService.Domain.Repositories;
using BikeRental.StationService.Responses;
using MediatR;

namespace BikeRental.StationService.Application.QueryHandlers
{
    public class GetByBikeQuery : IRequest<BikeAtStationResponse>
    {
        public int BikeId { get; set; }
    }

    public class GetByExternalQueryHandler : IRequestHandler<GetByBikeQuery, BikeAtStationResponse>
    {
        private readonly IBikeAtStationRepository _bikeAtStationRepository;

        public GetByExternalQueryHandler(IBikeAtStationRepository bikeAtStationRepository)
        {
            _bikeAtStationRepository = bikeAtStationRepository;
        }

        public Task<BikeAtStationResponse> Handle(GetByBikeQuery request, CancellationToken cancellationToken)
        {
            var bikeAtStation = _bikeAtStationRepository.GetByBike(request.BikeId)
                ?? throw new BikeNotAssignedToStationException(request.BikeId);

            return Task.FromResult(new BikeAtStationResponse
            {
                Id = bikeAtStation.Id,
                Code = bikeAtStation.Station.Code,
                Capacity = bikeAtStation.Station.Capacity,
                Location = bikeAtStation.Station.Location,
                StationId = bikeAtStation.StationId
            });
        }
    }
}
