using Xunit;
using Moq;
using Services;
using DTO;
using Entites;
using Repositories;
using Microsoft.Extensions.Logging;
using AutoMapper;

public class ServiceTests
{
    [Theory]
    [InlineData("123", false)]
    [InlineData("password", false)]
    [InlineData("StrongPassword123!", true)]
    public void ValidPassword_ReturnsExpectedResult(string password, bool expected)
    {
        var service = new Service(null, null, null); // בלי צורך ב־repo/mapper
        bool result = service.validPassword(password);
        Assert.Equal(expected, result);
    }

    [Fact]
    public async Task UpdateUser_LogsInformation()
    {
        // סידור תלויות
        var mockRepo = new Mock<IDisneyRepositorty>();
        var mockMapper = new Mock<IMapper>();
        var mockLogger = new Mock<ILogger<Service>>();

        var user = new User { UserId = 1, Password = "StrongPassword123!" };
        mockRepo.Setup(r => r.UpdateUser(It.IsAny<int>(), It.IsAny<User>())).ReturnsAsync(user);

        var service = new Service(mockRepo.Object, mockMapper.Object, mockLogger.Object);

        // פעולה
        await service.UpdateUser(1, user);

        // בדיקה אם נשלח לוג
        mockLogger.Verify(
            x => x.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Updating user")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception, string>>()),
            Times.Once);
    }
}
