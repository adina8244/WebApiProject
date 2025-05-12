using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbContext;

using Repositories;
using Services;
using Entites;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IDisneyRepositorty,DisneyRepositorty>();
builder.Services.AddTransient<IService,Service>();
builder.Services.AddDbContext <webApiDB8192Context>(option => option.UseSqlServer(@"Data Source=srv2\pupils;Initial Catalog=webApiDB8192;Integrated Security=True; Trusted_Connection=True;TrustServerCertificate=True"));


var app = builder.Build();


app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();

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