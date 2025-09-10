using BikeRental.BikeService.Domain.Entities;
using BikeRental.BikeService.Domain.Repositories;
using MediatR;

namespace BikeRental.BikeService.Controllers.Commands
{
    public class CreateBikeCommand : IRequest
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public DateOnly LastServiceDate { get; set; }
    }

    public class CreateBikeCommandHandler : IRequestHandler<CreateBikeCommand>
    {
        private readonly IBikeRepository _bikeRepository;

        public CreateBikeCommandHandler(IBikeRepository bikeRepository)
        {
            _bikeRepository = bikeRepository;
        }

        public async Task Handle(CreateBikeCommand request, CancellationToken cancellationToken)
        {
            await _bikeRepository.AddBike(new Bike
            {
                Model = request.Model,
                Color = request.Color,
                LastServiceDate = request.LastServiceDate,
            });

            await _bikeRepository.SaveChangesAsync();
        }
    }
}
