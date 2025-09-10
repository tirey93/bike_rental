using System.ComponentModel.DataAnnotations;

namespace BikeRental.StationService.Domain
{
    public class Entity
    {
        [Key]
        public int Id { get; private set; }
    }
}
