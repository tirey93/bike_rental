namespace BikeRental.BikeAtStationService.Domain.Entities.External
{
    public class Station : ExternalEntity
    {
        public Station() { }
        public Station(Guid externalId) : base(externalId) { }
    }
}
