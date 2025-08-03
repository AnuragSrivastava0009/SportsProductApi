using Microsoft.EntityFrameworkCore;
using SportsProductApi.Models;
using SportsProductApi.Services;
using SportsProductApi.Interfaces;
using SportsProductApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseInMemoryDatabase("ProductDb")); // Use SQL Server if needed

builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();               // Generates Swagger JSON
    app.UseSwaggerUI();            // Enables Swagger UI
}

app.ConfigureExceptionHandler(); // custom error handling
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();