using BikeRental.BikeService.Domain.Entities;

namespace BikeRental.BikeService.Domain.Repositories
{
    public interface IBikeRepository : IRepository<Bike>
    {
        Task AddBike(Bike bike);
        IEnumerable<Bike> Get();
    }
}
