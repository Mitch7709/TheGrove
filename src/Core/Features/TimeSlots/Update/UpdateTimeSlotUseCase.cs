using Core.Models;
using Core.Shared;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.TimeSlots.Update;

public class UpdateTimeSlotUseCase(IDbContext dbContext)
{
    public async Task<Result<UpdateTimeSlotResponse>> ExecuteAsync(int timeSlotId, UpdateTimeSlotRequest request)
    {
        var dayOfWeekParsed = Enum.Parse<DayOfWeek>(request.DayOfWeek, ignoreCase: true);

        var timeSlot = await dbContext.Set<TimeSlot>()
            .FirstOrDefaultAsync(ts => ts.Id == timeSlotId);

        if (timeSlot is null)
        {
            return Result.Failure(ErrorType.NotFound, $"TimeSlot with id {timeSlotId} was not found");
        }

        var exists = await dbContext.Set<TimeSlot>()
            .AnyAsync(ts => ts.Id != timeSlotId
                && ts.DayOfWeek == dayOfWeekParsed
                && ts.StartTime == request.StartTime
                && ts.DurationInMinutes == request.DurationInMinutes);

        if (exists)
        {
            return Result.Failure(ErrorType.Conflict, "A time slot with the same day, start time, and duration already exists.");
        }

        timeSlot.StartTime = request.StartTime;
        timeSlot.DurationInMinutes = request.DurationInMinutes;
        timeSlot.DayOfWeek = dayOfWeekParsed;
        timeSlot.IsActive = request.IsActive;

        await dbContext.SaveChangesAsync();

        return new UpdateTimeSlotResponse(
            timeSlot.Id,
            timeSlot.StartTime,
            timeSlot.DurationInMinutes,
            timeSlot.DayOfWeek,
            timeSlot.IsActive
        );
    }
}
