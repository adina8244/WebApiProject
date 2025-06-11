//using System;
//using System.Threading.Tasks;
//using Xunit;
//using Microsoft.EntityFrameworkCore;
//using Repositories;
//using Entites;
//using System.Collections.Generic;

//namespace IntegrationTests
//{
//    public class OrderRepositoryTests
//    {
//        private async Task<webApiDB8192Context> GetInMemoryDbContextAsync()
//        {
//            var options = new DbContextOptionsBuilder<webApiDB8192Context>()
//                .UseInMemoryDatabase(databaseName: "OrderTestDb_" + Guid.NewGuid())
//                .Options;

//            var context = new webApiDB8192Context(options);

//            // הוספת יוזר לדוגמה
//            var user = new User
//            {
//                UserId = 1,
//                UserName = "שרה כהן"
//            };

//            // הוספת מוצר לדוגמה (שימו לב: השם המקורי שלך למחלקה הוא Proudct)
//            var product = new Proudct
//            {
//                ProductId = 10,
//                ProductName = "בובה של מיקי מאוס",
//                Price = 50
//            };

//            context.Users.Add(user);
//            context.Proudcts.Add(product);
//            await context.SaveChangesAsync();

//            return context;
//        }

//        [Fact]
//        public async Task AddOrder_WithOrderItemsAndProduct_ShouldSucceed()
//        {
//            // Arrange
//            var context = await GetInMemoryDbContextAsync();
//            var repository = new OrderRepository(context);

//            var orderItem = new OrderItem
//            {
//                OrderItemId = 1,
//                ProductId = 10, // חייב להתאים ל־Product שקיים
//                Quantity = 2
//            };

//            var order = new Order
//            {
//                OrderId = 101,
//                OrderDate = "2025-06-11",
//                OrderSum = 100,
//                UserId = 1, // חייב להתאים ליוזר שהוספנו
//                OrderItems = new List<OrderItem> { orderItem }
//            };

//            // Act
//            var result = await repository.AddOrder(order);

//            // Assert
//            Assert.NotNull(result);
//            Assert.Equal(1, result.OrderItems.Count);
//            Assert.Equal(101, result.OrderId);

//            var savedOrderItem = await context.OrderItems.FirstOrDefaultAsync();
//            Assert.NotNull(savedOrderItem);
//            Assert.Equal(10, savedOrderItem.ProductId);
//            Assert.Equal(2, savedOrderItem.Quantity);
//        }
//    }
//}
