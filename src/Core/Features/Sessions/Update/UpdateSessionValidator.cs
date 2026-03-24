using FluentValidation;

namespace Core.Features.Sessions.Update;

public class UpdateSessionValidator : AbstractValidator<UpdateSessionRequest>
{
    public UpdateSessionValidator()
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
    }
}
