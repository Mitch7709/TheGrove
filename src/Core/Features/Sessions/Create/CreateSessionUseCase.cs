using Core.Models;
using Core.Shared;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Sessions.Create;

public class CreateSessionUseCase(IDbContext dbContext)
{
    public async Task<Result<CreateSessionResponse>> ExecuteAsync(CreateSessionRequest request)
    {
        var classTypeExists = await dbContext.Set<ClassType>()
            .AnyAsync(ct => ct.Id == request.ClassTypeId);

        if (!classTypeExists)
        {
            return Result.Failure(ErrorType.ValidationError, $"ClassType with id {request.ClassTypeId} not found.");
        }

        var instructorExists = await dbContext.Set<Instructor>()
            .AnyAsync(i => i.Id == request.InstructorId);

        if (!instructorExists)
        {
            return Result.Failure(ErrorType.ValidationError, $"Instructor with id {request.InstructorId} not found.");
        }

        var timeSlotExists = await dbContext.Set<TimeSlot>()
            .AnyAsync(ts => ts.Id == request.TimeSlotId);

        if (!timeSlotExists)
        {
            return Result.Failure(ErrorType.ValidationError, $"TimeSlot with id {request.TimeSlotId} not found.");
        }

        var session = new Session
        {
            ClassTypeId = request.ClassTypeId,
            InstructorId = request.InstructorId,
            TimeSlotId = request.TimeSlotId,
            Price = request.Price
        };

        dbContext.Set<Session>().Add(session);
        await dbContext.SaveChangesAsync();

        return new CreateSessionResponse(
            session.Id,
            session.ClassTypeId,
            session.InstructorId,
            session.TimeSlotId,
            session.Price
        );
    }
}
