namespace BikeRental.StationService.Contracts.Events
{
    public class BikeAtStationRemoveEvent
    {
        public Guid ExternalBikeId { get; set; }
        public Guid ExternalStationId { get; set; }
    }
}
