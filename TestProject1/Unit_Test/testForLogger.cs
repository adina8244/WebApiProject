using Xunit;
using Moq;
using Services;
using DTO;
using Entites;
using Repositories;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

public class ServiceTests
{
    [Fact]
    public async Task LogIn_SuccessfulLogin_WritesToLogger()
    {
        // Arrange
        var mockRepo = new Mock<IDisneyRepositorty>();
        var mockMapper = new Mock<IMapper>();
        var mockLogger = new Mock<ILogger<Service>>();

        var userLoginDTO = new UserLoginDTO { UserName = "testuser", Password = "password" };

        mockMapper.Setup(m => m.Map<UserLogin>(It.IsAny<UserLoginDTO>())).Returns(new UserLogin
        {
            UserName = "testuser",
            Password = "password"
        });

        mockRepo.Setup(r => r.logIn(It.IsAny<UserLogin>())).ReturnsAsync(new User
        {
            UserName = "testuser"
        });

        var service = new Service(mockRepo.Object, mockMapper.Object, mockLogger.Object);

        // Act
        var result = await service.logIn(userLoginDTO);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("testuser", result.UserName);

        mockLogger.Verify(
            x => x.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("testuser")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }

    [Fact]
    public void Service_Startup_WritesToLogger()
    {
        // Arrange
        var mockRepo = new Mock<IDisneyRepositorty>();
        var mockMapper = new Mock<IMapper>();
        var mockLogger = new Mock<ILogger<Service>>();

        // Act
        var service = new Service(mockRepo.Object, mockMapper.Object, mockLogger.Object);

        // Assert
        mockLogger.Verify(
            x => x.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Application started")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }
}