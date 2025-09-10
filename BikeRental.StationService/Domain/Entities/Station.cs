using BikeRental.StationService.Domain.Exceptions;

namespace BikeRental.StationService.Domain.Entities
{
    public class Station : ExternalEntity
    {
        public string Code { get; set; }

        public string Location { get; set; }

        public int Capacity { get; set; }

        public ICollection<BikeAtStation> BikesAtStation { get; private set; } = [];

        public void AddBike(Guid bikeExternalId)
        {
            if (BikesAtStation.Any(x => x.BikeExternalId == bikeExternalId)) 
            {
                throw new BikeAlreadyAtStationException(bikeExternalId, this);
            }

            BikesAtStation.Add(new BikeAtStation(this, bikeExternalId));
        }

        public void RemoveBike(Guid bikeExternalId)
        {
            var bikeAtStation = BikesAtStation.FirstOrDefault(x => x.BikeExternalId == bikeExternalId);
            if (bikeAtStation == null)
            {
                throw new BikeNotExistsAtStationException(bikeExternalId, this);
            }

            BikesAtStation.Remove(bikeAtStation);
        }
    }
}
