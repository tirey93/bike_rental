using System.ComponentModel.DataAnnotations;

namespace BikeRental.BikeService.Domain
{
    public class Entity
    {
        [Key]
        public int Id { get; private set; }
    }
}
