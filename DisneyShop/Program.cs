using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbContext;

using Repositories;
using Services;
using Entites;
using DisneyShop;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IDisneyRepositorty,DisneyRepositorty>();
builder.Services.AddTransient<ICategoriesReposetory, CategoriesReposetory>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();


builder.Services.AddTransient<IService,Service>();
builder.Services.AddTransient<ICategoriesService, CategoriesService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IOrderService, OrderService>();

builder.Services.AddDbContext<webApiDB8192Context>(option => option.UseSqlServer(@"Data Source=srv2\pupils;Initial Catalog=webApiDB8192;Integrated Security=True; Trusted_Connection=True;TrustServerCertificate=True"));
builder.Services.AddOpenApi();
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(MappingProfile));
var app = builder.Build();



app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "My API V1");
    });
}

// Map the default route to home.html
// Ensure that home.html loads properly
var directoryPath = Path.Combine(app.Environment.WebRootPath, "home.html");
if (!File.Exists(directoryPath))
{
    throw new FileNotFoundException("home.html is missing from wwwroot");
}

app.MapGet("/", async context =>
{
    context.Response.ContentType = "text/html";
    await context.Response.SendFileAsync(directoryPath);
});

app.MapControllers();
app.Run();