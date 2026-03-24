using FluentValidation;

namespace Core.Features.TimeSlots.Update;

public class UpdateTimeSlotValidator : AbstractValidator<UpdateTimeSlotRequest>
{
    public UpdateTimeSlotValidator()
    {
        RuleFor(x => x.DurationInMinutes)
            .GreaterThan(0)
            .WithMessage("DurationInMinutes must be greater than 0.")
            .LessThanOrEqualTo(1440)
            .WithMessage("DurationInMinutes must be less than or equal to 1440.");

        RuleFor(x => x.DayOfWeek)
            .IsInEnum()
            .WithMessage("DayOfWeek is invalid.");
    }
}
