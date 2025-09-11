using BikeRental.BikeService.Domain.Entities;
using BikeRental.BikeService.Domain.Repositories;
using MediatR;
using Rebus.Bus;

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
        private readonly IBus _bus;

        public CreateBikeCommandHandler(IBikeRepository bikeRepository, IBus bus)
        {
            _bikeRepository = bikeRepository;
            _bus = bus;
        }

        public async Task Handle(CreateBikeCommand request, CancellationToken cancellationToken)
        {
            await _bus.Publish("To jest moja testowa wiadomość! Hello RabbitMQ!");

            //await _bus.Publish(new BikeCreatedEvent
            //{
            //    Color = request.Color,
            //    ExternalBikeId = Guid.NewGuid(),
            //    LastServiceDate = request.LastServiceDate,
            //    Model = request.Model,
            //});
            //await _bikeRepository.AddBike(new Bike
            //{
            //    Model = request.Model,
            //    Color = request.Color,
            //    LastServiceDate = request.LastServiceDate,
            //});

            //await _bikeRepository.SaveChangesAsync();
        }
    }
}
