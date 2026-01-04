using BikeRental.BikeService.Application.Exceptions;
using BikeRental.BikeService.Contracts.Events;
using BikeRental.BikeService.Domain.Repositories;
using MediatR;
using Rebus.Bus;

namespace BikeRental.BikeService.Application.CommandHandlers
{
    public class UpdateBikeCommand : CreateBikeCommand
    {
        public int Id { get; set; }
    }

    public class UpdateBikeCommandHandler : IRequestHandler<UpdateBikeCommand>
    {
        private readonly IBikeRepository _bikeRepository;
        private readonly IBus _bus;

        public UpdateBikeCommandHandler(IBikeRepository bikeRepository, IBus bus)
        {
            _bikeRepository = bikeRepository;
            _bus = bus;
        }

        public async Task Handle(UpdateBikeCommand request, CancellationToken cancellationToken)
        {
            var bike = await _bikeRepository.Get(request.Id)
                ?? throw new BikeNotExistException(request.Id);
            bike.Color = request.Color;
            bike.Model = request.Model;
            bike.LastServiceDate = request.LastServiceDate;

            await _bikeRepository.SaveChangesAsync();

            await _bus.Publish(new BikeUpdatedEvent
            {
                ExternalBikeId = bike.ExternalId,
                Model = request.Model,
            });
        }
    }
}
