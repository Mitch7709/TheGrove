using Core.Models;
using Core.Shared;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Bookings.Read;

public class BookingReadService(IDbContext dbContext)
{
    public async Task<IReadOnlyList<BookingResponse>> GetAllAsync()
    {
        return await dbContext.Set<Booking>()
            .AsNoTracking()
            .OrderBy(b => b.Id)
            .Select(b => new BookingResponse(
                b.Id,
                new BookingSessionSummary(b.Session.Id, b.Session.SessionDate, b.Session.ClassType.Name),
                new BookingStudentSummary(b.Student.Id, $"{b.Student.AppUser.FirstName} {b.Student.AppUser.LastName}"),
                b.BookingDate,
                b.PaymentStatus,
                b.ConfirmationId,
                b.PriceAtBooking,
                b.BookingStatus
            ))
            .ToListAsync();
    }

    public async Task<Result<BookingResponse>> GetByIdAsync(int id)
    {
        var booking = await dbContext.Set<Booking>()
            .AsNoTracking()
            .Where(b => b.Id == id)
            .Select(b => new BookingResponse(
                b.Id,
                new BookingSessionSummary(b.Session.Id, b.Session.SessionDate, b.Session.ClassType.Name),
                new BookingStudentSummary(b.Student.Id, $"{b.Student.AppUser.FirstName} {b.Student.AppUser.LastName}"),
                b.BookingDate,
                b.PaymentStatus,
                b.ConfirmationId,
                b.PriceAtBooking,
                b.BookingStatus
            ))
            .FirstOrDefaultAsync();

        if (booking is null)
        {
            return Result.Failure(ErrorType.NotFound, $"Booking with id {id} not found.");
        }

        return booking;
    }
}
