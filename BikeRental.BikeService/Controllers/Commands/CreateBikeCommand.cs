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
        public Task Handle(CreateBikeCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
