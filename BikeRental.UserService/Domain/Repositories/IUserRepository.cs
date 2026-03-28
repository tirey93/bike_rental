using BikeRental.UserService.Domain.Entities;

namespace BikeRental.UserService.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task AddUser(User user);
        Task<User> Get(int id);
        Task<IEnumerable<User>> GetAll();
    }
}
