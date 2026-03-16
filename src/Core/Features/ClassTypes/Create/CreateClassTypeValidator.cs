using FluentValidation;
using Core.Models;

namespace Core.Features.ClassTypes.Create;

public class CreateClassTypeValidator : AbstractValidator<CreateClassTypeRequest>
{
    public CreateClassTypeValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .MaximumLength(ClassType.MaxLength.Name)
            .WithMessage($"Name must not exceed {ClassType.MaxLength.Name} characters.");

        RuleFor(x => x.Description)
            .MaximumLength(ClassType.MaxLength.Description)
            .WithMessage($"Description must not exceed {ClassType.MaxLength.Description} characters.");

        RuleFor(x => x.Style)
            .MaximumLength(ClassType.MaxLength.Style)
            .WithMessage($"Style must not exceed {ClassType.MaxLength.Style} characters.");

        RuleFor(x => x.Level)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Level must be 0 or greater.");
    }
}
