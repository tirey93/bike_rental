namespace BikeRental.BikeService.Domain.Entities
{
    public class Bike : ExternalEntity
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public DateOnly LastServiceDate { get; set; }
    }
}
