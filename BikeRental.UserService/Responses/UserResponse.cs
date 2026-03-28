namespace BikeRental.UserService.Responses
{
    public class UserResponse
    {
        public int Id { get; set; }
        public Guid ExternalId { get; set; }
        public string UserName { get; set; }
        public int Balance { get; set; }
    }
}
