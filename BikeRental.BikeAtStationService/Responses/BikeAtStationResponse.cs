namespace BikeRental.BikeAtStationService.Responses
{
    public class BikeAtStationResponse
    {
        public int Id { get; set; }
        public Guid BikeExternalId { get; set; }
        public Guid StationExternalId { get; set; }
    }
}
