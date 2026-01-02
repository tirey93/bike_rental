namespace BikeRental.BikeService.Application.Exceptions
{
    public class BikeNotExistException : ApplicationException
    {
        public BikeNotExistException(int id) : base($"Bike with id {id} not exists.")
        {

        }
    }
}
