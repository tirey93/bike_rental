namespace BikeRental.StationService.Responses
{
    public class BikeAtStationResponse
    {
        public int Id { get; set; }
        public int StationId { get; set; }

        public string Code { get; set; }

        public string Location { get; set; }

        public int Capacity { get; set; }
    }
}
