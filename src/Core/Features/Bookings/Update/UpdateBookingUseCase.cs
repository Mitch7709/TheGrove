using Core.Models;
using Core.Shared;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Bookings.Update;

public class UpdateBookingUseCase(IDbContext dbContext)
{
    public async Task<Result<UpdateBookingResponse>> ExecuteAsync(int bookingId, UpdateBookingRequest request)
    {
        var booking = await dbContext.Set<Booking>()
            .FirstOrDefaultAsync(b => b.Id == bookingId);

        if (booking is null)
        {
            return Result.Failure(ErrorType.NotFound, $"Booking with id {bookingId} was not found.");
        }

        var bookingStatusParsed = Enum.Parse<BookingStatus>(request.BookingStatus, ignoreCase: true);
        var paymentStatusParsed = Enum.Parse<PaymentStatus>(request.PaymentStatus, ignoreCase: true);

        booking.BookingStatus = bookingStatusParsed;
        booking.PaymentStatus = paymentStatusParsed;

        await dbContext.SaveChangesAsync();

        return new UpdateBookingResponse(
            booking.Id,
            booking.SessionId,
            booking.StudentId,
            booking.BookingDate,
            booking.PaymentStatus,
            booking.ConfirmationId,
            booking.PriceAtBooking,
            booking.BookingStatus
        );
    }
}
