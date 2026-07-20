using Pinterest.Api.Services;
using Microsoft.EntityFrameworkCore;
using Pinterest.Api.Data;
using Pinterest.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=Pinterest.db"));

builder.Services.AddScoped<PinService>();

// OpenAPI (.NET 9)
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();