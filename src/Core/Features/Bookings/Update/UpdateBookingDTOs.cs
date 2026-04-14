using Core.Models;

namespace Core.Features.Bookings.Update;

public record UpdateBookingRequest(
    string BookingStatus,
    string PaymentStatus
);

public record UpdateBookingResponse(
    int Id,
    int SessionId,
    int StudentId,
    DateTime BookingDate,
    PaymentStatus PaymentStatus,
    string ConfirmationId,
    decimal PriceAtBooking,
    BookingStatus BookingStatus
);
