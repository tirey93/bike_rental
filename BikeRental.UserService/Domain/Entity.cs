using System.ComponentModel.DataAnnotations;

namespace BikeRental.UserService.Domain
{
    public class Entity
    {
        [Key]
        public int Id { get; private set; }
    }
}
