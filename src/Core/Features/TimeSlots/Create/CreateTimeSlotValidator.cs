using Core.Models;
using FluentValidation;

namespace Core.Features.TimeSlots.Create;

public class CreateTimeSlotValidator : AbstractValidator<CreateTimeSlotRequest>
{
    public CreateTimeSlotValidator()
    {
        RuleFor(x => x.DurationInMinutes)
            .GreaterThan(0)
            .WithMessage("DurationInMinutes must be greater than 0.")
            .LessThanOrEqualTo(1440)
            .WithMessage("DurationInMinutes must be less than or equal to 1440.");

        RuleFor(x => x.DayOfWeek)
            .NotEmpty()
            .Must(value => Enum.TryParse<DayOfWeek>(value, ignoreCase: true, out _))
            .WithMessage("Provided DayOfWeek is invalid.");
    }
}
