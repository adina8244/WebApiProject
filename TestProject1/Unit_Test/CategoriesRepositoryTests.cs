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


public class CategoriesRepositoryTests
{
    [Fact]
    public async Task GetCategoryAsync_ReturnsAllCategoriesWithProducts()
    {
        // Arrange
        var categories = new List<Category>
        {
            new Category { CategoryId = 1, CategoryName = "Cat1", Proudcts = new List<Proudct>() },
            new Category { CategoryId = 2, CategoryName = "Cat2", Proudcts = new List<Proudct>() }
        }.AsQueryable();

        var mockSet = new Mock<DbSet<Category>>();

        mockSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(categories.Provider);
        mockSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(categories.Expression);
        mockSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(categories.ElementType);
        mockSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(categories.GetEnumerator());

        mockSet.As<IAsyncEnumerable<Category>>()
            .Setup(m => m.GetAsyncEnumerator(It.IsAny<CancellationToken>()))
            .Returns(new TestAsyncEnumerator<Category>(categories.GetEnumerator()));

        var mockContext = new Mock<webApiDB8192Context>();
        mockContext.Setup(c => c.Categories).Returns(mockSet.Object);

        var repository = new CategoriesReposetory(mockContext.Object);

        // Act
        var result = await repository.getCategoryAsync();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal("Cat1", result[0].CategoryName);
        Assert.Equal("Cat2", result[1].CategoryName);
    }
}
