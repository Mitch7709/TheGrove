using Core.Models;
using Core.Shared;

namespace Core.Features.Bookings.Delete;

public class DeleteBookingUseCase(IDbContext dbContext)
{
    public async Task<Result> ExecuteAsync(int id)
    {
        var booking = await dbContext.Set<Booking>().FindAsync(id);

        if (booking is null)
        {
            return Result.Failure(ErrorType.NotFound, $"Booking with id {id} not found.");
        }

        dbContext.Set<Booking>().Remove(booking);
        await dbContext.SaveChangesAsync();

        return Result.Success();
    }
}
