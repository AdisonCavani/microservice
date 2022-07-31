using Microsoft.EntityFrameworkCore;
using PlatformService.Database;
using PlatformService.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionSettings = new ConnectionSettings();
builder.Configuration.GetSection(nameof(ConnectionSettings)).Bind(connectionSettings);
connectionSettings.Validate();

builder.Services.AddDbContextPool<AppDbContext>(options =>
{
    options.UseNpgsql(connectionSettings.SqlConnectionString, npgOptions =>
    {
        npgOptions.EnableRetryOnFailure();
    });
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();