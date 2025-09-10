namespace BikeRental.StationService.Domain.Entities
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message) { }
    }
}
