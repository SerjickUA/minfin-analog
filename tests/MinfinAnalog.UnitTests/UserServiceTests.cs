using AutoMapper;
using MinfinAnalog.Domain.DTOs;
using MinfinAnalog.Domain.Entities;
using MinfinAnalog.Domain.Interfaces;
using MinfinAnalog.Domain.Mapping;
using MinfinAnalog.Domain.Services;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace MinfinAnalog.UnitTests;

public class UserServiceTests
{
    private readonly UserService _userService;
    private readonly Mock<IUserRepository> _userRepoMock = new();
    private readonly Mock<IUnitOfWork> _unitOfWorkMock = new();
    public UserServiceTests()
    {
        var userProfile = new UserProfile();
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(userProfile));
        IMapper mapper = new Mapper(configuration);
        _userService = new UserService(_userRepoMock.Object, _unitOfWorkMock.Object, mapper);
    }
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task GetByIdAsync_ShouldReturnUser_WhenUserExists()
    {
        // Arrange
        var userId = 1;
        const string firstName = "Sergiy";
        const string lastName = "Ivanov";
        const string userEmail = "serjickua@gmail.com";

        var user = new User()
        {
            Email = userEmail,
            FirstName = firstName,
            LastName = lastName
        };

        _userRepoMock.Setup(x => x.GetByIdAsync(userId)).ReturnsAsync(user);

        // Act
        var result = await _userService.GetUserByIdAsync(userId);
        // Assert
        Assert.AreEqual(result.Email, user.Email);
    }
}
