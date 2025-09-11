using BikeRental.BikeService.Contracts.Events;
using BikeRental.BikeService.Domain.Entities;
using BikeRental.BikeService.Domain.Repositories;
using MediatR;
using Rebus.Bus;

namespace BikeRental.BikeService.Application.CommandHandlers
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
        private readonly IBus _bus;

        public CreateBikeCommandHandler(IBikeRepository bikeRepository, IBus bus)
        {
            _bikeRepository = bikeRepository;
            _bus = bus;
        }

        public async Task Handle(CreateBikeCommand request, CancellationToken cancellationToken)
        {
            var bike = new Bike
            {
                Model = request.Model,
                Color = request.Color,
                LastServiceDate = request.LastServiceDate,
            };
            await _bikeRepository.AddBike(bike);

            await _bus.Publish(new BikeCreatedEvent
            {
                ExternalBikeId = bike.ExternalId,
            });
            await _bikeRepository.SaveChangesAsync();
        }
    }
}
