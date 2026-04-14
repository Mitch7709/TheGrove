using Core.Models;

namespace Core.Features.Bookings.Read;

public record BookingResponse(
    int Id,
    BookingSessionSummary Session,
    BookingStudentSummary Student,
    DateTime BookingDate,
    PaymentStatus PaymentStatus,
    string ConfirmationId,
    decimal PriceAtBooking,
    BookingStatus BookingStatus
);

public record BookingSessionSummary(int Id, DateOnly SessionDate, string ClassTypeName);
public record BookingStudentSummary(int Id, string Name);
