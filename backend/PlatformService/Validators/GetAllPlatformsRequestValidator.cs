using FluentValidation;
using PlatformService.Contracts.Requests;

namespace PlatformService.Validators;

public class GetAllPlatformsRequestValidator : AbstractValidator<GetAllPlatformsRequest>
{
    public GetAllPlatformsRequestValidator()
    {
        RuleFor(x => x.Page)
            .NotNull()
            .GreaterThanOrEqualTo(1);
    }
}