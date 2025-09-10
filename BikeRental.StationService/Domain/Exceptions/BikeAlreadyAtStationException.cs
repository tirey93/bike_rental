using BikeRental.StationService.Domain.Entities;

namespace BikeRental.StationService.Domain.Exceptions
{
    public class BikeAlreadyAtStationException : DomainException
    {
        public BikeAlreadyAtStationException(Guid bikeExternalId, Station station) 
            : base($"Bike with externalId {bikeExternalId} is already at station with external id {station.ExternalId}")
        {

        }
    }
}
