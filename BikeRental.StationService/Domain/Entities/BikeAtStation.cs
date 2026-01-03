using BikeRental.StationService.Domain.Entities.External;

namespace BikeRental.StationService.Domain.Entities
{
    public class BikeAtStation : Entity
    {
        public Station Station { get; private set; }

        public int StationId { get; private set; }

        public Bike Bike { get; private set; }

        public int BikeId { get; private set; }

        public BikeAtStation() { }

        public BikeAtStation(Station station, Bike bike)
        {
            Station = station;
            StationId = station.Id;
            Bike = bike;
            BikeId = bike.Id;
        }
    }
}
