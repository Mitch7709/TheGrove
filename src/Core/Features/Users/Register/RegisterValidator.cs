using Core.Models;
using FluentValidation;

namespace Core.Features.Users.Register;

public class RegisterValidator : AbstractValidator<RegisterRequest>
{
    public RegisterValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(6);

        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(AppUser.MaxLength.FirstName);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(AppUser.MaxLength.LastName);

        RuleFor(x => x.PhoneNumber)
            .Matches(@"^\d{3}-?\d{3}-?\d{4}$");
    }
}