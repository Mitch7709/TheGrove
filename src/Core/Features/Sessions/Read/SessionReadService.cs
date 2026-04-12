using Core.Models;
using Core.Shared;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Sessions.Read;

public class SessionReadService(IDbContext dbContext)
{
    public async Task<IReadOnlyList<SessionResponse>> GetAllAsync()
    {
        return await dbContext.Set<Session>()
            .AsNoTracking()
            .OrderBy(s => s.Id)
            .Select(s => new SessionResponse(
                s.Id,
                new ClassTypeSummary(s.ClassType.Id, s.ClassType.Name, s.ClassType.Style, s.ClassType.Level),
                new InstructorSummary(s.Instructor.Id, s.Instructor.AppUser.UserName!),
                new TimeSlotSummary(s.TimeSlot.Id, s.TimeSlot.DayOfWeek, s.TimeSlot.StartTime, s.TimeSlot.DurationInMinutes),
                s.Price,
                s.SessionDate,
                s.Status
            ))
            .ToListAsync();
    }

    public async Task<Result<SessionResponse>> GetByIdAsync(int id)
    {
        var session = await dbContext.Set<Session>()
            .AsNoTracking()
            .Where(s => s.Id == id)
            .Select(s => new SessionResponse(
                s.Id,
                new ClassTypeSummary(s.ClassType.Id, s.ClassType.Name, s.ClassType.Style, s.ClassType.Level),
                new InstructorSummary(s.Instructor.Id, s.Instructor.AppUser.UserName!),
                new TimeSlotSummary(s.TimeSlot.Id, s.TimeSlot.DayOfWeek, s.TimeSlot.StartTime, s.TimeSlot.DurationInMinutes),
                s.Price,
                s.SessionDate,
                s.Status
            ))
            .FirstOrDefaultAsync();

        if (session is null)
        {
            return Result.Failure(ErrorType.NotFound, $"Session with id {id} not found.");
        }

        return session;
    }
}
