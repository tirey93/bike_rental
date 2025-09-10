using System.ComponentModel.DataAnnotations;

namespace BikeRental.BikeService.Domain
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }

        public Guid ExternalId { get; set; }
    }
}
