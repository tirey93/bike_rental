namespace BikeRental.UserService.Application.Exceptions
{
    public class UserAlreadyExistsException : ApplicationException
    {
        public UserAlreadyExistsException(string userName) : base($"User with username '{userName}' already exists.")
        {
        }
    }
}
