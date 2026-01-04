namespace BikeRental.BikeService.Responses
{
    public class StationResponse
    {
        public string Code { get; set; }

        public string Location { get; set; }

        public int Capacity { get; set; }

        public int BikesInStation { get; set; }
    }
}
