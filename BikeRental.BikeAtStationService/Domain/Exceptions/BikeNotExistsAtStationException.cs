namespace BikeRental.BikeAtStationService.Domain.Exceptions
{
    public class BikeNotExistsAtStationException : DomainException
    {
        public BikeNotExistsAtStationException(Guid bikeExternalId, Guid stationExternalId) 
            : base($"Bike with externalId {bikeExternalId} not exists at station with external id {stationExternalId}")
        {
        }
    }
}
