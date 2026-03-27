namespace BikeRental.BikeService.Responses
{
    public class BikeAtStationResponse
    {
        public int Id { get; set; }
        public Guid ExternalStationId { get; set; }
        public string Code { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
    }
}
