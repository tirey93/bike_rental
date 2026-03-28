namespace BikeRental.UserService.Domain.Entities
{
    public class User : Entity
    {
        public string UserName { get; set; }
        public string HashedPassword { get; set; }
        public int Balance { get; set; }

        public User() { }

        public User(string userName, string hashedPassword, int balance)
        {
            UserName = userName;
            HashedPassword = hashedPassword;
            Balance = balance;
        }
    }
}
