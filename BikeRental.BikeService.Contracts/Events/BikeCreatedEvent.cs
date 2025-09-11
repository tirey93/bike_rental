
namespace BikeRental.BikeService.Contracts.Events
{
    public class BikeCreatedEvent
    {
        public Guid ExternalBikeId { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public DateOnly LastServiceDate { get; set; }
    }
}
