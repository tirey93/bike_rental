namespace BikeRental.StationService.Application.Exceptions
{
    public class BikeNotAssignedToStationException : ApplicationException
    {
        public BikeNotAssignedToStationException(int id) : base($"Bike with id {id} not assigned to any station.")
        {

        }
    }
}
