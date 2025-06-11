using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Entites;
using Repositories;
using Moq;
using Moq.EntityFrameworkCore;
using Xunit;
using Microsoft.EntityFrameworkCore;

namespace TestProject1.Unit_Test
{
    public class TestDisneyRepository
    {
        //[Fact]
        //public async Task addUserRegister_AddsUserCorrectly()
        //{
        //    var user = new User { UserId = 1, UserName = "Mickey", Password = "1234" };
        //    var mockContext = new Mock<webApiDB8192Context>();
        //    var users = new List<User>();
        //    mockContext.Setup(x => x.Users).ReturnsDbSet(users);

        //    var repository = new DisneyRepositorty(mockContext.Object);

        //    await repository.addUserRegister(user);

        //    mockContext.Verify(x => x.Users.AddAsync(user, It.IsAny<CancellationToken>()), Times.Once);
        //    mockContext.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        //}
        //[Fact]
        //public async Task logIn_ValidUser_ReturnsUser()
        //{
        //    var user = new User { UserId = 1, UserName = "Donald", Password = "duck" };
        //    var mockContext = new Mock<webApiDB8192Context>();
        //    var users = new List<User>() { user };
        //    mockContext.Setup(x => x.Users).ReturnsDbSet(users);

        //    var repository = new DisneyRepositorty(mockContext.Object);

        //    var loginDetails = new UserLogin { UserName = "Donald", Password = "duck" };

        //    var result = await repository.logIn(loginDetails);

        //    Assert.Equal(user, result);
        //}
        //[Fact]
        //public async Task logIn_NotValidUser_ReturnsNull()
        //{
        //    var user = new User { UserId = 1, UserName = "Donald", Password = "duck" };
        //    var mockContext = new Mock<webApiDB8192Context>();
        //    var users = new List<User>() { user };
        //    mockContext.Setup(x => x.Users).ReturnsDbSet(users);

        //    var repository = new DisneyRepositorty(mockContext.Object);

        //    var loginDetails = new UserLogin { UserName = "Goofy", Password = "dog" };

        //    var result = await repository.logIn(loginDetails);

        //    Assert.Null(result);
        //}
        //[Fact]
        //public async Task UpdateUser_UpdatesCorrectly()
        //{
        //    // Arrange
        //    var users = new List<User>
        //{
        //    new User { UserId = 1, UserName = "OldName", Password = "1234" }
        //}.AsQueryable();

        //    var mockSet = new Mock<DbSet<User>>();
        //    mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(users.Provider);
        //    mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(users.Expression);
        //    mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(users.ElementType);
        //    mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(users.GetEnumerator());
        //    mockSet.Setup(m => m.FindAsync(1)).ReturnsAsync(users.First());

        //    var mockContext = new Mock<webApiDB8192Context>(new DbContextOptions<webApiDB8192Context>());
        //    mockContext.Setup(c => c.Users).Returns(mockSet.Object);

        //    var repo = new DisneyRepositorty(mockContext.Object);

        //    var updatedUser = new User
        //    {
        //        UserName = "NewName",
        //        Password = "5678",
        //        FirstName = "John",
        //        LastName = "Doe"
        //    };

        //    // Act
        //    var result = await repo.UpdateUser(1, updatedUser);

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.Equal("NewName", result.UserName);
        //    Assert.Equal("5678", result.Password);
        //    Assert.Equal("John", result.FirstName);
        //    Assert.Equal("Doe", result.LastName);
        //    mockContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
        //}
    }
}
