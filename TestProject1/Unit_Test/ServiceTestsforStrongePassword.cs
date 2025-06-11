using Xunit;
using Services;
using Moq;
using Microsoft.Extensions.Logging;

namespace TestProject1.Unit_Test
{
    public class ServiceTestsforStrongePassword
    {
        [Fact]
        public void ValidPassword_ShouldReturnFalse_ForWeakPassword()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<Service>>();
            var service = new Service(null, null, loggerMock.Object);

            // Act
            bool result = service.validPassword("123");

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void ValidPassword_ShouldReturnTrue_ForStrongPassword()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<Service>>();
            var service = new Service(null, null, loggerMock.Object);

            // Act
            bool result = service.validPassword("Str0ngP@ssw0rd!");

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Service_Startup_WritesToLogger()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<Service>>();

            // Act
            var service = new Service(null, null, loggerMock.Object);

            // Assert
            loggerMock.Verify(
                x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Application started")),
                    null,
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                Times.Once);
        }
    }
}