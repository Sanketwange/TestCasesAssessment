using AuthService.Common;
using Moq;
using OrderAPP.Repo;
using OrderAPP.Repo.Abstract;
using OrderAPP.Services;
using Solution.Core.Entity;
using System.Threading.Tasks;
using Xunit;

namespace OrderTestCases
{
    public class UserServiceTest
    {

        private readonly Mock<IUserRepo> _mockUserRepo;
        private readonly UserService _userService;

        public UserServiceTest()
        {
            _mockUserRepo = new Mock<IUserRepo>();
            _userService = new UserService(_mockUserRepo.Object);
        }

        [Fact]
        public async Task GetUserById_ReturnsUser_WhenUserExists()
        {
            // Arrange
            var userId = 1;
            var expectedUser = new Users { Id = 1, FullName = "Test", Email = "test@example.com", Password = "Test", Username = "Test", Role = UserRolesEnum.User };

            _mockUserRepo
                .Setup(repo => repo.GetUserById(userId))
                .ReturnsAsync(expectedUser);

            // Act
            var result = await _userService.GetUserById(userId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userId, result?.Id);
            Assert.Equal("Test", result?.FullName);
        }

        [Fact]
        public async Task GetUserById_ReturnsNull_WhenUserDoesNotExist()
        {
            // Arrange
            var userId = 99;

            _mockUserRepo
                .Setup(repo => repo.GetUserById(userId))
                .ReturnsAsync((Users?)null);

            // Act
            var result =await _userService.GetUserById(userId);

            // Assert
            Assert.Null(result);
        }

    }
}
