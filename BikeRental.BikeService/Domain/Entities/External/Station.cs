namespace BikeRental.BikeService.Domain.Entities.External
{
    public class Station : ExternalEntity
    {
        public string Code { get; set; }

        public string Location { get; set; }

        public int Capacity { get; set; }

        public Station() { }
        public Station(Guid externalId) : base(externalId) { }
    }
}
