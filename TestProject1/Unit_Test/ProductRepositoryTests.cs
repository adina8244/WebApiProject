//using Xunit;
//using Moq;
//using Microsoft.EntityFrameworkCore;
//using Repositories;
//using Entites;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using System.Linq;
//using System.Threading;
//using Microsoft.EntityFrameworkCore.Query;
//using System.Linq.Expressions;

//public class ProductRepositoryTests
//{
//    private Mock<webApiDB8192Context> _mockContext;
//    private Mock<DbSet<Proudct>> _mockSet;

//    private List<Proudct> _products = new List<Proudct>
//    {
//        new Proudct { ProductId = 1, ProductName = "Product1", Price = 100, Description = "Desc1" },
//        new Proudct { ProductId = 2, ProductName = "Product2", Price = 200, Description = "Desc2" }
//    };

//    public ProductRepositoryTests()
//    {
//        _mockSet = CreateMockDbSet(_products.AsQueryable());
//        _mockContext = new Mock<webApiDB8192Context>();
//        _mockContext.Setup(c => c.Proudcts).Returns(_mockSet.Object);
//    }

//    [Fact]
//    public async Task GetProudctAsync_ReturnsAllProducts()
//    {
//        // Arrange
//        var repository = new ProductRepository(_mockContext.Object);

//        // Act
//        var result = await repository.GetProudctAsync();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(2, result.Count);
//        Assert.Equal("Product1", result[0].ProductName);
//    }

//    // פונקציה שמייצרת Mock ל-DbSet תומך ב-async
//    private static Mock<DbSet<T>> CreateMockDbSet<T>(IQueryable<T> data) where T : class
//    {
//        var mockSet = new Mock<DbSet<T>>();

//        mockSet.As<IAsyncEnumerable<T>>()
//            .Setup(m => m.GetAsyncEnumerator(It.IsAny<CancellationToken>()))
//            .Returns(new TestAsyncEnumerator<T>(data.GetEnumerator()));

//        mockSet.As<IQueryable<T>>()
//            .Setup(m => m.Provider)
//            .Returns(new TestAsyncQueryProvider<T>(data.Provider));

//        mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
//        mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
//        mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

//        return mockSet;
//    }
//}

//// תמיכה ב-async enumeration
//internal class TestAsyncEnumerator<T> : IAsyncEnumerator<T>
//{
//    private readonly IEnumerator<T> _inner;

//    public TestAsyncEnumerator(IEnumerator<T> inner)
//    {
//        _inner = inner;
//    }

//    public ValueTask DisposeAsync()
//    {
//        _inner.Dispose();
//        return default;
//    }

//    public ValueTask<bool> MoveNextAsync()
//    {
//        return new ValueTask<bool>(_inner.MoveNext());
//    }

//    public T Current => _inner.Current;
//}

//// תמיכה ב-async query provider
//internal class TestAsyncQueryProvider<TEntity> : IAsyncQueryProvider
//{
//    private readonly IQueryProvider _inner;

//    public TestAsyncQueryProvider(IQueryProvider inner)
//    {
//        _inner = inner;
//    }

//    public IQueryable CreateQuery(Expression expression)
//    {
//        return new TestAsyncEnumerable<TEntity>(expression);
//    }

//    public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
//    {
//        return new TestAsyncEnumerable<TElement>(expression);
//    }

//    public object Execute(Expression expression)
//    {
//        return _inner.Execute(expression);
//    }

//    public TResult Execute<TResult>(Expression expression)
//    {
//        return _inner.Execute<TResult>(expression);
//    }

//    public IAsyncEnumerable<TResult> ExecuteAsync<TResult>(Expression expression)
//    {
//        return new TestAsyncEnumerable<TResult>(expression);
//    }

//    public Task<TResult> ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken)
//    {
//        return Task.FromResult(Execute<TResult>(expression));
//    }

//    TResult IAsyncQueryProvider.ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken)
//    {
//        throw new NotImplementedException();
//    }
//}

//internal class TestAsyncEnumerable<T> : EnumerableQuery<T>, IAsyncEnumerable<T>, IQueryable<T>
//{
//    public TestAsyncEnumerable(IEnumerable<T> enumerable)
//        : base(enumerable)
//    { }

//    public TestAsyncEnumerable(Expression expression)
//        : base(expression)
//    { }

//    public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
//    {
//        return new TestAsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());
//    }

//    IQueryProvider IQueryable.Provider => new TestAsyncQueryProvider<T>(this);
//}
