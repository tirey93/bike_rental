using System.ComponentModel.DataAnnotations.Schema;

namespace BikeRental.BikeService.Domain.Entities
{
    public class Bike : ExternalEntity
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public DateOnly LastServiceDate { get; set; }

        [ForeignKey(nameof(BikeAtStationId))]
        public BikeAtStation BikeAtStation { get; private set; }

        public int? BikeAtStationId { get; private set; }
    }
}
