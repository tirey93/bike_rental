namespace BikeRental.BikeService.Responses
{
    public class BikeResponse
    {
        public int Id { get; set; }
        public Guid ExternalId { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public DateOnly LastServiceDate { get; set; }
    }
}
