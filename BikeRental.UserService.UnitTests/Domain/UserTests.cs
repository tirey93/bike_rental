using BikeRental.UserService.Domain.Entities;
using FluentAssertions;

namespace BikeRental.UserService.UnitTests.Domain
{
    public class UserTests
    {
        [Fact]
        public void Constructor_WithValidParameters_ShouldCreateUserWithHashedPassword()
        {
            // Arrange
            var userName = "testuser";
            var plainPassword = "password123";
            var balance = 100;

            // Act
            var user = new User(userName, plainPassword, balance);

            // Assert
            user.UserName.Should().Be(userName);
            user.Balance.Should().Be(balance);
            user.HashedPassword.Should().NotBeNullOrEmpty();
            user.HashedPassword.Should().NotBe(plainPassword);
        }

        [Fact]
        public void VerifyPassword_WithCorrectPassword_ShouldReturnTrue()
        {
            // Arrange
            var plainPassword = "password123";
            var user = new User("testuser", plainPassword, 100);

            // Act
            var result = user.VerifyPassword(plainPassword);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void VerifyPassword_WithIncorrectPassword_ShouldReturnFalse()
        {
            // Arrange
            var user = new User("testuser", "correctPassword", 100);

            // Act
            var result = user.VerifyPassword("wrongPassword");

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void VerifyPassword_WithEmptyPassword_ShouldReturnFalse()
        {
            // Arrange
            var user = new User("testuser", "somePassword", 100);

            // Act
            var result = user.VerifyPassword("");

            // Assert
            result.Should().BeFalse();
        }

        [Theory]
        [InlineData("short")]
        [InlineData("verylongpasswordwithmanycharacters")]
        [InlineData("!@#$%^&*()_+")]
        [InlineData("password with spaces")]
        public void Constructor_WithVariousPasswords_ShouldHashCorrectly(string password)
        {
            // Act
            var user = new User("testuser", password, 100);

            // Assert
            user.VerifyPassword(password).Should().BeTrue();
        }
    }
}
