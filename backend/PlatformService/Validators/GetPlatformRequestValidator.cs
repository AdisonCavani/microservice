using FluentValidation;
using PlatformService.Contracts.Requests;

namespace PlatformService.Validators;

public class GetPlatformRequestValidator : AbstractValidator<GetPlatformRequest>
{
    public GetPlatformRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .GreaterThanOrEqualTo(1);
    }
}