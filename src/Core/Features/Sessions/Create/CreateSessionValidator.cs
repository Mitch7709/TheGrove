using FluentValidation;

namespace Core.Features.Sessions.Create;

public class CreateSessionValidator : AbstractValidator<CreateSessionRequest>
{
    public CreateSessionValidator()
    {
        RuleFor(x => x.ClassTypeId)
            .GreaterThan(0)
            .WithMessage("ClassTypeId must be greater than 0.");

        RuleFor(x => x.InstructorId)
            .GreaterThan(0)
            .WithMessage("InstructorId must be greater than 0.");

        RuleFor(x => x.TimeSlotId)
            .GreaterThan(0)
            .WithMessage("TimeSlotId must be greater than 0.");

        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithMessage("Price must be greater than 0.");

        RuleFor(x => x.SessionDate)
            .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today))
            .WithMessage("SessionDate must be today or in the future.");

        RuleFor(x => x.Status)
            .IsInEnum()
            .WithMessage("Status must be a valid SessionStatus value.");
    }
}
