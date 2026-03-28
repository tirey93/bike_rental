using BikeRental.UserService.Domain.Repositories;
using BikeRental.UserService.Responses;
using MediatR;

namespace BikeRental.UserService.Application.QueryHandlers
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UserResponse>>
    {
    }

    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserResponse>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserResponse>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAll();
            return users.Select(u => new UserResponse
            {
                Id = u.Id,
                ExternalId = u.ExternalId,
                UserName = u.UserName,
                Balance = u.Balance
            });
        }
    }
}
