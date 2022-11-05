using FluentValidation.AspNetCore;
using PlatformService.Database;
using PlatformService.Services;
using PlatformService.Settings;
using PlatformService.Startup;

var builder = WebApplication.CreateBuilder(args);

// Program
builder.WebHost.AddAwsParameterStore();

// Configure services
var connectionSettings = new ConnectionSettings();
builder.Configuration.GetSection(nameof(ConnectionSettings)).Bind(connectionSettings);
connectionSettings.Validate();
builder.Services.ConfigureSettings(builder.Configuration);
builder.Services.ConfigureDbContext(connectionSettings);
builder.Services.AddServices();
builder.Services.AddValidators();
builder.Services.AddGrpc();
builder.Services.AddControllers().AddFluentValidation();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
    options.DescribeAllParametersInCamelCase();
});

var app = builder.Build();

// Configure
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

await app.SeedDataAsync();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapGrpcService<GrpcPlatformService>();

app.Run();