using System.ComponentModel.DataAnnotations;

namespace BikeRental.BikeAtStationService.Domain
{
    public class Entity
    {
        [Key]
        public int Id { get; private set; }
    }
}
