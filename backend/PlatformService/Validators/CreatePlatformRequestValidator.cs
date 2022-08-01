using FluentValidation;
using PlatformService.Contracts.Requests;

namespace PlatformService.Validators;

public class CreatePlatformRequestValidator : AbstractValidator<CreatePlatformRequest>
{
    public CreatePlatformRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Cost).NotEmpty();
        RuleFor(x => x.Publisher).NotEmpty();
    }
}