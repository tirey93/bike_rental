using BikeRental.UserService.Domain.Entities;
using BikeRental.UserService.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BikeRental.UserService.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext appDbContext)
            : base(appDbContext, appDbContext.Users)
        {
        }

        public async Task AddUser(User user)
        {
            await _dbSet.AddAsync(user);
        }

        public async Task<User> Get(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }
    }
}
