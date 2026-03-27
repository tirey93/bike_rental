namespace BikeRental.BikeAtStationService.Domain.Exceptions
{
    public class BikeAlreadyAtStationException : DomainException
    {
        public BikeAlreadyAtStationException(Guid bikeExternalId, Guid stationExternalId) 
            : base($"Bike with externalId {bikeExternalId} is already at station with external id {stationExternalId}")
        {
        }
    }
}
