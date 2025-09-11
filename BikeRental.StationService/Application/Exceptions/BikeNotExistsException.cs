namespace BikeRental.StationService.Application.Exceptions
{
    public class BikeNotExistsException : ApplicationException
    {
        public BikeNotExistsException(Guid externalBikeId): base($"Bike with external id {externalBikeId} not exists.")
        {

        }
    }
}
