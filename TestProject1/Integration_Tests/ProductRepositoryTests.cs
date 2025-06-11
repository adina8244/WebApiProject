//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using Xunit;
//using Microsoft.EntityFrameworkCore;
//using Repositories;
//using Entites;

//namespace IntegrationTests
//{
//    public class ProductRepositoryTests
//    {
//        private async Task<webApiDB8192Context> GetInMemoryDbContextAsync()
//        {
//            var options = new DbContextOptionsBuilder<webApiDB8192Context>()
//                .UseInMemoryDatabase(databaseName: "ProductTestDb_" + Guid.NewGuid())
//                .Options;

//            var context = new webApiDB8192Context(options);

//            // יצירת קטגוריה לדוגמה (כי יש קשר בין Proudct ל-Category)
//            var category = new Category
//            {
//                CategoryId = 1,
//                CategoryName = "צעצועים"
//            };

//            context.Categories.Add(category);
//            await context.SaveChangesAsync();

//            return context;
//        }

//        [Fact]
//        public async Task GetProudctAsync_ShouldReturnProductsWithCategory()
//        {
//            // Arrange
//            var context = await GetInMemoryDbContextAsync();

//            var product = new Proudct
//            {
//                ProductId = 1,
//                ProductName = "בובת דיסני",
//                CategoryId = 1
//            };

//            context.Proudcts.Add(product);
//            await context.SaveChangesAsync();

//            var repository = new ProductRepository(context);

//            // Act
//            var result = await repository.GetProudctAsync();

//            // Assert
//            Assert.NotNull(result);
//            Assert.Single(result);
//            Assert.Equal("בובת דיסני", result[0].ProductName);
//            Assert.NotNull(result[0].Category);
//            Assert.Equal("צעצועים", result[0].Category.CategoryName);
//        }
//    }
//}
