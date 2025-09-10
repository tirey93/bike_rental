using System.ComponentModel.DataAnnotations;

namespace BikeRental.StationService.Domain
{
    public class Entity
    {
        [Key]
        public int Id { get; private set; }

        public Guid ExternalId { get; private set; }

        public Entity()
        {
            ExternalId = Guid.NewGuid();
        }
    }
}
