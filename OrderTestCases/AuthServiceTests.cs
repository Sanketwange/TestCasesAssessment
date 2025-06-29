using Moq;
using OrderAPP.Repo.Abstract;
using OrderAPP.Services;
using Solution.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OrderTestCases
{
    public class AuthServiceTests
    {
        private readonly UserAuthService _authService;
        private readonly Mock<IUserRepo> _mockUserRepo;

        public AuthServiceTests()
        {
            _mockUserRepo = new Mock<IUserRepo>();
            _authService = new UserAuthService(_mockUserRepo.Object);
        }

        [Theory]
        [InlineData("Password1", true)]      // Valid
        [InlineData("password1", false)]     // No uppercase
        [InlineData("PASSWORD", false)]      // No number
        [InlineData("Pass", false)]          // Too short
        [InlineData("12345678", false)]      // No letters
        [InlineData("password", false)]      // No uppercase or number
        [InlineData("Valid123", true)]       // Valid
        [InlineData("", false)]              // Empty string
        [InlineData("        ", false)]      // Spaces only
        public void IsValidPassword_ReturnsExpectedResult(string password, bool expected)
        {
            // Act
            var result = _authService.IsValidPassword(password);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task IsEmailRegisteredAsync_ReturnsTrue_WhenUserExists()
        {
            // Arrange
            string email = "test@example.com";
            var user = new Users { Id = 1, Email = email };

            _mockUserRepo.Setup(repo => repo.GetUserByEmailAsync(email))
                         .ReturnsAsync(user);

            // Act
            var result = await _authService.IsEmailRegisteredAsync(email);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task IsEmailRegisteredAsync_ReturnsFalse_WhenUserDoesNotExist()
        {
            // Arrange
            string email = "unknown@example.com";

            _mockUserRepo.Setup(repo => repo.GetUserByEmailAsync(email))
                         .ReturnsAsync((Users?)null);

            // Act
            var result = await _authService.IsEmailRegisteredAsync(email);

            // Assert
            Assert.False(result);
        }
    }
}
