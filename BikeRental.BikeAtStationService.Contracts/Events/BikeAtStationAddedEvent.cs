namespace BikeRental.BikeAtStationService.Contracts.Events
{
    public class BikeAtStationAddedEvent
    {
        public Guid ExternalBikeId { get; set; }
        public Guid ExternalStationId { get; set; }
    }
}
