using BikeRental.BikeService.Domain.Repositories;
using BikeRental.BikeService.Responses;
using MediatR;

namespace BikeRental.BikeService.Controllers.Queries
{
    public class GetAllBikesQuery : IRequest<IEnumerable<BikeResponse>>
    {

    }

    public class GetAllBikesQueryHandler : IRequestHandler<GetAllBikesQuery, IEnumerable<BikeResponse>>
    {
        private readonly IBikeRepository _bikeRepository;

        public GetAllBikesQueryHandler(IBikeRepository bikeRepository)
        {
            _bikeRepository = bikeRepository;
        }

        public Task<IEnumerable<BikeResponse>> Handle(GetAllBikesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_bikeRepository.Get().Select(bike =>
                new BikeResponse
                {
                    Id = bike.Id,
                    ExternalId = bike.ExternalId,
                    Model = bike.Model,
                    Color = bike.Color,
                    LastServiceDate = bike.LastServiceDate,
                }));
        }
    }
}
