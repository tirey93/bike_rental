using BikeRental.UserService.Domain.Entities;
using BikeRental.UserService.Domain.Repositories;
using MediatR;

namespace BikeRental.UserService.Application.CommandHandlers
{
    public class CreateUserCommand : IRequest
    {
        public string UserName { get; set; }
        public string HashedPassword { get; set; }
        public int Balance { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.UserName, request.HashedPassword, request.Balance);
            await _userRepository.AddUser(user);
            await _userRepository.SaveChangesAsync();
        }
    }
}
