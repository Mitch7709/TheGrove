using Core.Models;
using FluentValidation;

namespace Core.Features.Bookings.Update;

public class UpdateBookingValidator : AbstractValidator<UpdateBookingRequest>
{
    public UpdateBookingValidator()
    {
        RuleFor(x => x.BookingStatus)
            .NotEmpty()
            .WithMessage("BookingStatus is required.")
            .Must(s => Enum.TryParse<BookingStatus>(s, ignoreCase: true, out _))
            .WithMessage("BookingStatus must be a valid BookingStatus value.");

        RuleFor(x => x.PaymentStatus)
            .NotEmpty()
            .WithMessage("PaymentStatus is required.")
            .Must(s => Enum.TryParse<PaymentStatus>(s, ignoreCase: true, out _))
            .WithMessage("PaymentStatus must be a valid PaymentStatus value.");
    }
}
