
namespace BikeRental.BikeService.Contracts.Events
{
    public class BikeUpdatedEvent
    {
        public Guid ExternalBikeId { get; set; }

        public string Model { get; set; }
    }
}
