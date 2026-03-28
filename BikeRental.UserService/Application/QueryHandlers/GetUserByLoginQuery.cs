using BikeRental.UserService.Domain.Repositories;
using BikeRental.UserService.Responses;
using MediatR;

namespace BikeRental.UserService.Application.QueryHandlers
{
    public class GetUserByLoginQuery : IRequest<UserResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class GetUserByLoginQueryHandler : IRequestHandler<GetUserByLoginQuery, UserResponse>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByLoginQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserResponse> Handle(GetUserByLoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUserName(request.UserName);
            if (user == null)
            {
                return null;
            }

            if (!user.VerifyPassword(request.Password))
            {
                return null;
            }

            return new UserResponse
            {
                Id = user.Id,
                ExternalId = user.ExternalId,
                UserName = user.UserName,
                Balance = user.Balance
            };
        }
    }
}
