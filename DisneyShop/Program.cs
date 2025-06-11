using Microsoft.EntityFrameworkCore;
using NLog.Web;
using Repositories;
using Services;
using Entites;
using DisneyShop;

var builder = WebApplication.CreateBuilder(args);

// הגדרות לוגינג
builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(LogLevel.Trace);
builder.Host.UseNLog();

// הוספת שירותים ל־DI
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IDisneyRepositorty, DisneyRepositorty>();
builder.Services.AddTransient<ICategoriesReposetory, CategoriesReposetory>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();

builder.Services.AddTransient<IService, Service>();
builder.Services.AddTransient<ICategoriesService, CategoriesService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IOrderService, OrderService>();

builder.Services.AddDbContext<webApiDB8192Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDisneyDB")));

builder.Services.AddOpenApi();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// לוג כשהאפליקציה עלתה
var logger = app.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("The application has started successfully.❤️😥😂😁❤️");

// סטטיים, https
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "My API V1");
    });
}

// בדיקת קובץ home.html
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

var testLogger = app.Services.GetRequiredService<ILogger<Program>>();
testLogger.LogWarning("🟡 בדיקת NLog - אם אתה רואה את זה, NLog עובד!");

app.MapControllers();

app.Run();