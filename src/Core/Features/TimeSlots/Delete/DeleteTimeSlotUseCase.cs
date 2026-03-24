using Core.Models;
using Core.Shared;

namespace Core.Features.TimeSlots.Delete;

public class DeleteTimeSlotUseCase(IDbContext dbContext)
{
    public async Task<Result> ExecuteAsync(int id)
    {
        var timeSlot = await dbContext.Set<TimeSlot>().FindAsync(id);
        if (timeSlot is null)
        {
            return Result.Failure(ErrorType.NotFound, $"TimeSlot with id {id} not found.");
        }

        dbContext.Set<TimeSlot>().Remove(timeSlot);
        await dbContext.SaveChangesAsync();

        return Result.Success();
    }
}
