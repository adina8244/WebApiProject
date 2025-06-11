using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Entites;
using System.Linq;

namespace IntegrationTests
{
    public class CategoriesRepositoryTests
    {
        private async Task<webApiDB8192Context> GetInMemoryDbContextAsync()
        {
            var options = new DbContextOptionsBuilder<webApiDB8192Context>()
                .UseInMemoryDatabase(databaseName: "TestDb_" + System.Guid.NewGuid())
                .Options;

            var context = new webApiDB8192Context(options);

            // הוספת דאטה לדוגמה
            var categories = new List<Category>
            {
                new Category { CategoryId = 1, CategoryName = "Toys", Proudcts = new List<Proudct>
                {
                    new Proudct { ProductId = 1, ProductName = "Mickey Mouse Toy" }
                }},
                new Category { CategoryId = 2, CategoryName = "Clothes", Proudcts = new List<Proudct>() }
            };

            context.Categories.AddRange(categories);
            await context.SaveChangesAsync();

            return context;
        }

        [Fact]
        public async Task GetCategoryAsync_ReturnsAllCategories_WithProductsIncluded()
        {
            // Arrange
            var context = await GetInMemoryDbContextAsync();
            var repository = new CategoriesReposetory(context);

            // Act
            var result = await repository.getCategoryAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Contains(result, c => c.CategoryName == "Toys" && c.Proudcts.Any(p => p.ProductName == "Mickey Mouse Toy"));
            Assert.Contains(result, c => c.CategoryName == "Clothes");
        }
    }
}

