namespace BikeRental.StationService.Responses
{
    public class StationResponse
    {
        public int Id { get; set; }

        public Guid ExternalId { get; set; }

        public string Code { get; set; }

        public string Location { get; set; }

        public int Capacity { get; set; }
    }
}
