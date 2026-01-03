using BikeRental.StationService.Domain.Entities.External;
using BikeRental.StationService.Domain.Exceptions;

namespace BikeRental.StationService.Domain.Entities
{
    public class Station : ExternalEntity
    {
        public string Code { get; set; }

        public string Location { get; set; }

        public int Capacity { get; set; }

        public ICollection<BikeAtStation> BikesAtStation { get; private set; } = [];

        public void AddBike(Bike bike)
        {
            if (BikesAtStation.Any(x => x.Bike.Id == bike.Id)) 
            {
                throw new BikeAlreadyAtStationException(bike.ExternalId, this);
            }

            BikesAtStation.Add(new BikeAtStation(this, bike));
        }

        public void RemoveBike(Bike bike)
        {
            var bikeAtStation = BikesAtStation.FirstOrDefault(x => x.Bike.Id == bike.Id);
            if (bikeAtStation == null)
            {
                throw new BikeNotExistsAtStationException(bike.ExternalId, this);
            }

            BikesAtStation.Remove(bikeAtStation);
        }
    }
}
