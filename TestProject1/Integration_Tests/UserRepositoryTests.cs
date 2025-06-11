using System;
using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Entites;
using DTO;

namespace IntegrationTests
{
    public class UserRepositoryTests
    {
        private async Task<webApiDB8192Context> GetInMemoryDbContextAsync()
        {
            var options = new DbContextOptionsBuilder<webApiDB8192Context>()
                .UseInMemoryDatabase(databaseName: "DisneyTestDb_" + Guid.NewGuid())
                .Options;

            var context = new webApiDB8192Context(options);

            // אפשר להוסיף משתמשים התחלתיים כאן במידת הצורך

            await context.SaveChangesAsync();
            return context;
        }

        [Fact]
        public async Task AddUserRegister_ShouldAddUser()
        {
            // Arrange
            var context = await GetInMemoryDbContextAsync();
            var repository = new DisneyRepositorty(context);

            var newUser = new User
            {
                UserId = 1,
                UserName = "naomi",
                Password = "password123"
            };

            // Act
            var addedUser = await repository.addUserRegister(newUser);

            // Assert
            Assert.NotNull(addedUser);
            Assert.Equal("naomi", addedUser.UserName);

            var userInDb = await context.Users.FindAsync(1);
            Assert.NotNull(userInDb);
            Assert.Equal("naomi", userInDb.UserName);
        }

        [Fact]
        public async Task LogIn_ShouldReturnUser_WhenCredentialsAreCorrect()
        {
            // Arrange
            var context = await GetInMemoryDbContextAsync();

            var user = new User
            {
                UserId = 2,
                UserName = "lali",
                Password = "secret"
            };
            context.Users.Add(user);
            await context.SaveChangesAsync();

            var repository = new DisneyRepositorty(context);

            var loginDto = new UserLogin
            {
                UserName = "lali",
                Password = "secret"
            };

            // Act
            var loggedInUser = await repository.logIn(loginDto);

            // Assert
            Assert.NotNull(loggedInUser);
            Assert.Equal(user.UserName, loggedInUser.UserName);
        }

        [Fact]
        public async Task LogIn_ShouldReturnNull_WhenCredentialsAreIncorrect()
        {
            // Arrange
            var context = await GetInMemoryDbContextAsync();

            var user = new User
            {
                UserId = 3,
                UserName = "dani",
                Password = "mypassword"
            };
            context.Users.Add(user);
            await context.SaveChangesAsync();

            var repository = new DisneyRepositorty(context);

            var wrongLoginDto = new UserLogin
            {
                UserName = "dani",
                Password = "wrongpassword"
            };

            // Act
            var loggedInUser = await repository.logIn(wrongLoginDto);

            // Assert
            Assert.Null(loggedInUser);
        }

        [Fact]
        public async Task UpdateUser_ShouldModifyExistingUser()
        {
            // Arrange
            var context = await GetInMemoryDbContextAsync();

            var user = new User
            {
                UserId = 4,
                UserName = "eli",
                Password = "oldpass"
            };
            context.Users.Add(user);
            await context.SaveChangesAsync();

            var repository = new DisneyRepositorty(context);

            var updatedUser = new User
            {
                UserId = 4,
                UserName = "eli",
                Password = "newpass"
            };

            // Act
            var result = await repository.UpdateUser(4, updatedUser);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("newpass", result.Password);

            var userInDb = await context.Users.FindAsync(4);
            Assert.Equal("newpass", userInDb.Password);
        }
    }
}

