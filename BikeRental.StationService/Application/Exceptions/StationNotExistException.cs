namespace BikeRental.StationService.Application.Exceptions
{
    public class StationNotExistException : ApplicationException
    {
        public StationNotExistException(int id) : base($"Station with id {id} not exists.")
        {

        }

        public StationNotExistException(Guid externalId) : base($"Station with external id {externalId} not exists.")
        {

        }
    }
}
