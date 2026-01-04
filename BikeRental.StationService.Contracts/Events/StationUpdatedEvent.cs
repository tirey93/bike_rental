
namespace BikeRental.StationService.Contracts.Events
{
    public class StationUpdatedEvent
    {
        public Guid ExternalStationId { get; set; }

        public string Code { get; set; }

        public string Location { get; set; }

        public int Capacity { get; set; }
    }
}
