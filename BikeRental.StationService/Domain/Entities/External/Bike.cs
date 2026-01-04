namespace BikeRental.StationService.Domain.Entities.External
{
    public class Bike : ExternalEntity
    {
        public string Model { get; set; }
        public string Color { get; set; }

        public Bike() { }
        public Bike(Guid externalId) :base(externalId) { }
    }
}
