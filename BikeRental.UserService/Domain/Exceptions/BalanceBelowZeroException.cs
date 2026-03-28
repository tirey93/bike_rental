namespace BikeRental.UserService.Domain.Exceptions
{
    public class BalanceBelowZeroException : DomainException
    {
        public BalanceBelowZeroException() : base("Balance cannot be negative")
        {
        }
    }
}
