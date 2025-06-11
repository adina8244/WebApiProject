using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Entites;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Threading;

using TestProject1.Unit_Test;

public class ProductRepositoryTests
{
    private Mock<webApiDB8192Context> _mockContext;
    private Mock<DbSet<Proudct>> _mockSet;

    private List<Proudct> _products = new List<Proudct>
    {
        new Proudct { ProductId = 1, ProductName = "Product1", Price = 100, Description = "Desc1" },
        new Proudct { ProductId = 2, ProductName = "Product2", Price = 200, Description = "Desc2" }
    };

    public ProductRepositoryTests()
    {
        _mockSet = CreateMockDbSet(_products.AsQueryable());
        _mockContext = new Mock<webApiDB8192Context>();
        _mockContext.Setup(c => c.Proudcts).Returns(_mockSet.Object);
    }

    [Fact]
    public async Task GetProudctAsync_ReturnsAllProducts()
    {
        var repository = new ProductRepository(_mockContext.Object);
        var result = await repository.GetProudctAsync();

        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Equal("Product1", result[0].ProductName);
    }

    private static Mock<DbSet<T>> CreateMockDbSet<T>(IQueryable<T> data) where T : class
    {
        var mockSet = new Mock<DbSet<T>>();

        mockSet.As<IAsyncEnumerable<T>>()
            .Setup(m => m.GetAsyncEnumerator(It.IsAny<CancellationToken>()))
            .Returns(new TestAsyncEnumerator<T>(data.GetEnumerator()));

        mockSet.As<IQueryable<T>>()
            .Setup(m => m.Provider)
            .Returns(new TestAsyncQueryProvider<T>(data.Provider));

        mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        return mockSet;
    }
}
