using FluentValidation;
using PlatformService.Contracts.Requests;
using PlatformService.Validators;

namespace PlatformService.Startup;

public static class Validators
{
    public static void AddValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<CreatePlatformRequest>, CreatePlatformRequestValidator>();
        services.AddScoped<IValidator<GetAllPlatformsRequest>, GetAllPlatformsRequestValidator>();
        services.AddScoped<IValidator<GetPlatformRequest>, GetPlatformRequestValidator>();
    }
}