using BikeRental.BikeService.Application.Exceptions;
using BikeRental.BikeService.Contracts.Events;
using BikeRental.BikeService.Domain.Repositories;
using MediatR;
using Rebus.Bus;

namespace BikeRental.BikeService.Application.CommandHandlers
{
    public class DeleteBikeCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteBikeCommandHandler : IRequestHandler<DeleteBikeCommand>
    {
        private readonly IBikeRepository _bikeRepository;
        private readonly IBikeAtStationRepository _bikeAtStationRepository;
        private readonly IBus _bus;

        public DeleteBikeCommandHandler(IBikeRepository bikeRepository, IBikeAtStationRepository bikeAtStationRepository, IBus bus)
        {
            _bikeRepository = bikeRepository;
            _bikeAtStationRepository = bikeAtStationRepository;
            _bus = bus;
        }

        public async Task Handle(DeleteBikeCommand request, CancellationToken cancellationToken)
        {
            var bike = await _bikeRepository.Get(request.Id)
                ?? throw new BikeNotExistException(request.Id);

            if (bike.BikeAtStation != null)
            {
                _bikeAtStationRepository.Remove(bike.BikeAtStation);
                await _bikeAtStationRepository.SaveChangesAsync();
            }
            _bikeRepository.Remove(bike);
            await _bikeRepository.SaveChangesAsync();

            await _bus.Publish(new BikeDeletedEvent
            {
                ExternalBikeId = bike.ExternalId,
            });
        }
    }
}
