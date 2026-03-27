namespace BikeRental.BikeAtStationService.Contracts.Events
{
    public class BikeAtStationRemovedEvent
    {
        public Guid ExternalBikeId { get; set; }
        public Guid ExternalStationId { get; set; }
    }
}
