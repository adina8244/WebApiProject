using DTO;
using Entites;
using Moq;
using Moq.EntityFrameworkCore;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entites;
using Microsoft.EntityFrameworkCore;

namespace TestProject1
{
    public class UserTestReposetory
    {
        [Fact]
        public async Task GetUser_ValidCredentials_ReturnUser()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<webApiDB8192Context>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using var context = new webApiDB8192Context(options);

            var user = new User { UserName = "1", FirstName = "E", LastName = "C", Password = "1234EeCc@" };
            context.Users.Add(user);
            await context.SaveChangesAsync();

            var userRepository = new DisneyRepositorty(context);
            var loginRequest = new UserLogin { UserName = user.UserName, Password = user.Password };

            // Act
            var result = await userRepository.logIn(loginRequest);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(user.UserName, result.UserName); 
        }

        //[Fact]
        //public async Task GetUser_ValidCredentials_ReturnUser()
        //{
        //    //Arrange
        //    var user = new User { UserName = "1", FirstName = "E", LastName = "C", Password = "1234EeCc@" };

        //    var mockContext = new Mock<webApiDB8192Context>();
        //    var users = new List<User>() { user };
        //    mockContext.Setup(u => u.Users).ReturnsDbSet(users);

        //    var userRepository = new DisneyRepositorty(mockContext.Object);
        //    var loginRequest = new UserLogin { UserName = user.UserName, Password = user.Password };

        //           //Act
        //    var result = await userRepository.logIn(loginRequest);

        //    //Assert
        //    Assert.NotNull(result);
        //    Assert.Equal(user, result);
        //}
    }
}
