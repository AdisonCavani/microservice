using FluentValidation.AspNetCore;
using PlatformService.Database;
using PlatformService.Repositories;
using PlatformService.Startup;

var builder = WebApplication.CreateBuilder(args);

// Program
builder.WebHost.AddAwsParameterStore();

// Configure services
builder.Services.ConfigureDbContext(builder.Configuration, builder.Environment);
builder.Services.AddScoped<IPlatformRepository, PlatformRepository>();
builder.Services.AddValidators();
builder.Services.AddControllers().AddFluentValidation();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure
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