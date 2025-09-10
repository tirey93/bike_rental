namespace BikeRental.StationService.Domain.Entities
{
    public class BikeAtStation : Entity
    {
        public Station Station { get; private set; }

        public int StationId { get; private set; }

        public Guid BikeExternalId { get; private set; }

        public BikeAtStation() { }

        public BikeAtStation(Station station, Guid bikeExternalId)
        {
            Station = station;
            StationId = station.Id;
            BikeExternalId = bikeExternalId;
        }
    }
}
