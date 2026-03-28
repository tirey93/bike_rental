using BikeRental.UserService.Domain.Exceptions;
using System.Security.Cryptography;
using System.Text;

namespace BikeRental.UserService.Domain.Entities
{
    public class User : ExternalEntity
    {
        public string UserName { get; set; }
        public string HashedPassword { get; private set; }
        public int Balance { get; private set; }

        public User() { }

        public User(string userName, string plainPassword, int balance)
        {
            UserName = userName;
            var bytes = Encoding.UTF8.GetBytes(plainPassword);
            var hash = SHA256.HashData(bytes);
            HashedPassword = Convert.ToBase64String(hash);
            Balance = balance;
        }

        public bool VerifyPassword(string plainPassword)
        {
            var bytes = Encoding.UTF8.GetBytes(plainPassword);
            var hash = SHA256.HashData(bytes);
            var hashString = Convert.ToBase64String(hash);
            return HashedPassword == hashString;
        }

        public void SetBalance(int balance)
        {
            if (balance < 0)
            {
                throw new BalanceBelowZeroException();
            }
            Balance = balance;
        }
    }
}
