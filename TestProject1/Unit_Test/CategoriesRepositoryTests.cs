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

//public class CategoriesRepositoryTests
//{
//    [Fact]
//    public async Task GetCategoryAsync_ReturnsAllCategoriesWithProducts()
//    {
//        // Arrange - יצירת נתוני דמה
//        var categories = new List<Category>
//        {
//            new Category { CategoryId = 1, CategoryName = "Cat1", Proudcts = new List<Proudct>() },
//            new Category { CategoryId = 2, CategoryName = "Cat2", Proudcts = new List<Proudct>() }
//        }.AsQueryable();

//        // יצירת Mock ל-DbSet<Category>
//        var mockSet = new Mock<DbSet<Category>>();

//        mockSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(categories.Provider);
//        mockSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(categories.Expression);
//        mockSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(categories.ElementType);
//        mockSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(categories.GetEnumerator());

//        mockSet.As<IAsyncEnumerable<Category>>()
//            .Setup(m => m.GetAsyncEnumerator(It.IsAny<CancellationToken>()))
//            .Returns(new TestAsyncEnumerator<Category>(categories.GetEnumerator()));

//        mockSet.As<IQueryable<Category>>()
//            .Setup(m => m.Provider)
//            .Returns(new TestAsyncQueryProvider<Category>(categories.Provider));

//        // יצירת Mock ל-context
//        var mockContext = new Mock<webApiDB8192Context>();
//        mockContext.Setup(c => c.Categories).Returns(mockSet.Object);

//        // יצירת instance של הריפוזיטורי
//        var repository = new CategoriesReposetory(mockContext.Object);

//        // Act
//        var result = await repository.getCategoryAsync();

//        // Assert
//        Assert.Equal(2, result.Count);
//        Assert.Equal("Cat1", result[0].CategoryName);
//        Assert.Equal("Cat2", result[1].CategoryName);
//    }
//}

//// תמיכה ב-async enumerator ו-query provider
//internal class TestAsyncQueryProvider<TEntity> : IAsyncQueryProvider
//{
//    private readonly IQueryProvider _inner;
//    internal TestAsyncQueryProvider(IQueryProvider inner) { _inner = inner; }
//    public IQueryable CreateQuery(Expression expression) => new TestAsyncEnumerable<TEntity>(expression);
//    public IQueryable<TElement> CreateQuery<TElement>(Expression expression) => new TestAsyncEnumerable<TElement>(expression);
//    public object Execute(Expression expression) => _inner.Execute(expression);
//    public TResult Execute<TResult>(Expression expression) => _inner.Execute<TResult>(expression);
//    public IAsyncEnumerable<TResult> ExecuteAsync<TResult>(Expression expression) => new TestAsyncEnumerable<TResult>(expression);
//    public Task<TResult> ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken) => Task.FromResult(Execute<TResult>(expression));

//    TResult IAsyncQueryProvider.ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken)
//    {
//        throw new NotImplementedException();
//    }
//}

//internal class TestAsyncEnumerable<T> : EnumerableQuery<T>, IAsyncEnumerable<T>, IQueryable<T>
//{
//    public TestAsyncEnumerable(IEnumerable<T> enumerable) : base(enumerable) { }
//    public TestAsyncEnumerable(Expression expression) : base(expression) { }
//    public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default) => new TestAsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());
//    IQueryProvider IQueryable.Provider => new TestAsyncQueryProvider<T>(this);
//}

//internal class TestAsyncEnumerator<T> : IAsyncEnumerator<T>
//{
//    private readonly IEnumerator<T> _inner;
//    public TestAsyncEnumerator(IEnumerator<T> inner) { _inner = inner; }
//    public ValueTask DisposeAsync() { _inner.Dispose(); return ValueTask.CompletedTask; }
//    public ValueTask<bool> MoveNextAsync() => new ValueTask<bool>(_inner.MoveNext());
//    public T Current => _inner.Current;
//}


//public interface IAsyncQueryProvider : IQueryProvider
//{
//    TResult ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken = default);
//}
