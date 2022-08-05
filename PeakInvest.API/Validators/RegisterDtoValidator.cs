using FluentValidation;
using PeakInvest.API.Models;

namespace PeakInvest.API.Validators;

public class RegisterDtoValidator : AbstractValidator<RegisterDto>
{
    public RegisterDtoValidator()
    {
        RuleFor(x => x.Times)
            .GreaterThan(0)
            .NotEmpty();

        RuleFor(x => x.Value)
            .GreaterThan(0)
            .NotEmpty();
    }
}