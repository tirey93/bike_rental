using BikeRental.UserService.Domain.Repositories;
using BikeRental.UserService.Responses;
using MediatR;

namespace BikeRental.UserService.Application.QueryHandlers
{
    public class GetUserByIdQuery : IRequest<UserResponse>
    {
        public int Id { get; set; }
    }

    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserResponse>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.Get(request.Id);
            if (user == null)
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
