namespace BikeRental.StationService.Domain.Entities.External
{
    public class Bike : ExternalEntity
    {
        public Bike() { }
        public Bike(Guid externalId) :base(externalId) { }
    }
}
