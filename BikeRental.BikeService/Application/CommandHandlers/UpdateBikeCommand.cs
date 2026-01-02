using BikeRental.BikeService.Application.Exceptions;
using BikeRental.BikeService.Domain.Repositories;
using MediatR;

namespace BikeRental.BikeService.Application.CommandHandlers
{
    public class UpdateBikeCommand : CreateBikeCommand
    {
        public int Id { get; set; }
    }

    public class UpdateBikeCommandHandler : IRequestHandler<UpdateBikeCommand>
    {
        private readonly IBikeRepository _bikeRepository;

        public UpdateBikeCommandHandler(IBikeRepository bikeRepository)
        {
            _bikeRepository = bikeRepository;
        }

        public async Task Handle(UpdateBikeCommand request, CancellationToken cancellationToken)
        {
            var bike = await _bikeRepository.Get(request.Id)
                ?? throw new BikeNotExistException(request.Id);
            bike.Color = request.Color;
            bike.Model = request.Model;
            bike.LastServiceDate = request.LastServiceDate;

            await _bikeRepository.SaveChangesAsync();
        }
    }
}
