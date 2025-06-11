using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Entites;
using System.Threading.Tasks;
using System.Threading;
using System;

public class OrderRepositoryTests
{
    private Mock<webApiDB8192Context> _mockContext;
    private Mock<DbSet<Order>> _mockSet;

    public OrderRepositoryTests()
    {
        _mockSet = new Mock<DbSet<Order>>();
        _mockContext = new Mock<webApiDB8192Context>();

        _mockContext.Setup(c => c.Orders).Returns(_mockSet.Object);
        _mockContext.Setup(c => c.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);
    }

    [Fact]
    public async Task AddOrder_AddsOrderAndSavesChanges()
    {
        // Arrange
        var repository = new OrderRepository(_mockContext.Object);
        var order = new Order
        {
            OrderDate = "2025-06-11",
            OrderSum = 1000,
            UserId = 1
        };

        // Act
        var result = await repository.AddOrder(order);

        // Assert
        _mockSet.Verify(s => s.AddAsync(order, It.IsAny<CancellationToken>()), Times.Once);
        _mockContext.Verify(c => c.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        Assert.Equal(order, result);
    }

    [Fact]
    public async Task AddOrder_SaveChangesThrowsException_Throws()
    {
        // Arrange
        var repository = new OrderRepository(_mockContext.Object);
        var order = new Order();

        _mockContext.Setup(c => c.SaveChangesAsync(It.IsAny<CancellationToken>()))
            .ThrowsAsync(new DbUpdateException("DB Error"));

        // Act & Assert
        await Assert.ThrowsAsync<DbUpdateException>(() => repository.AddOrder(order));
        _mockSet.Verify(s => s.AddAsync(order, It.IsAny<CancellationToken>()), Times.Once);
        _mockContext.Verify(c => c.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }
}
