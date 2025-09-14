namespace BikeRental.BikeService.Domain.Entities.External
{
    public class BikeAtStation : Entity
    {
        public Bike Bike { get; private set; }
        public Guid StationExternalId { get; private set; }

        public BikeAtStation()
        {
        }

        public BikeAtStation(Bike bike, Guid stationExternalId)
        {
            Bike = bike;
            StationExternalId = stationExternalId;
        }
    }
}
