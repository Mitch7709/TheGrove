using Core.Models;

namespace Core.Features.Bookings.Create;

public record CreateBookingRequest(
    int SessionId,
    int StudentId
);

public record CreateBookingResponse(
    int Id,
    int SessionId,
    int StudentId,
    DateTime BookingDate,
    PaymentStatus PaymentStatus,
    string ConfirmationId,
    decimal PriceAtBooking,
    BookingStatus BookingStatus
);
