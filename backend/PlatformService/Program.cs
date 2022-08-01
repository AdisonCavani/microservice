using Microsoft.EntityFrameworkCore;
using PlatformService.Database;
using PlatformService.Repositories;
using PlatformService.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContextPool<AppDbContext>(options =>
{
    options.UseInMemoryDatabase("platform-service");
});
builder.Services.AddScoped<IPlatformRepository, PlatformRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.SeedData();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();