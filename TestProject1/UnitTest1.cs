using DTO;
using Entites;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System.Threading.Tasks;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public async Task Register_UniqueUsername_AddsUserToDatabase()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<webApiDB8192Context>()
                .UseInMemoryDatabase(databaseName: "RegisterTestDb")
                .Options;

            using var context = new webApiDB8192Context(options);

            var userRepository = new DisneyRepositorty(context);

            var newUser = new User
            {
                UserName = "newUser123",
                FirstName = "Test",
                LastName = "User",
                Password = "Test@123"
            };

            // Act
            var result = await userRepository.addUserRegister(newUser);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(newUser.UserName, result.UserName);

            var userInDb = await context.Users.FirstOrDefaultAsync(u => u.UserName == "newUser123");
            Assert.NotNull(userInDb);
        }
    }
}
