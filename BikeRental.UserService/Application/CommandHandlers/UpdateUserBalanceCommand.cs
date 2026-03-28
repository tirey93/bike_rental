using BikeRental.UserService.Domain.Entities;
using BikeRental.UserService.Domain.Repositories;
using MediatR;

namespace BikeRental.UserService.Application.CommandHandlers
{
    public class UpdateUserBalanceCommand : IRequest
    {
        public int UserId { get; set; }
        public int Balance { get; set; }
    }

    public class UpdateUserBalanceCommandHandler : IRequestHandler<UpdateUserBalanceCommand>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserBalanceCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(UpdateUserBalanceCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.Get(request.UserId) 
                ?? throw new Exception($"User with id {request.UserId} not found");
            user.SetBalance(request.Balance);
            await _userRepository.SaveChangesAsync();
        }
    }
}
