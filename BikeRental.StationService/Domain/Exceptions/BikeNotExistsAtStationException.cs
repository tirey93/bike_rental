using BikeRental.StationService.Domain.Entities;

namespace BikeRental.StationService.Domain.Exceptions
{
    public class BikeNotExistsAtStationException : DomainException
    {
        public BikeNotExistsAtStationException(Guid bikeExternalId, Station station) 
            : base($"Bike with externalId {bikeExternalId} not exists at station with external id {station.ExternalId}")
        {

        }
    }
}
