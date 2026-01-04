using BikeRental.BikeService.Domain.Entities.External;

namespace BikeRental.BikeService.Domain.Entities
{
    public class BikeAtStation : Entity
    {
        public Bike Bike { get; private set; }
        public int BikeId { get; set; }
        public Station Station { get; private set; }
        public int StationId { get; set; }

        public BikeAtStation() { }

        public BikeAtStation(Bike bike, Station station)
        {
            Bike = bike;
            BikeId = bike.Id;
            Station = station;
            StationId = station.Id;
        }
    }
}
