using System;
using Core.Models;
using Core.Shared;

namespace Core.Features.Instructors.Delete;

public class DeleteInstructorUseCase(IDbContext dbContext)
{
    public async Task<Result> ExecuteAsync(int id)
    {
        var instructor = await dbContext.Set<Instructor>().FindAsync(id);
        if (instructor is null)
        {
            return Result.Failure(ErrorType.NotFound, $"Instructor with id {id} not found.");
        }

        dbContext.Set<Instructor>().Remove(instructor);

        var appUser = await dbContext.Set<AppUser>().FindAsync(instructor.UserId);
        if (appUser is not null)
        {
            dbContext.Set<AppUser>().Remove(appUser);
        }

        await dbContext.SaveChangesAsync();
        return Result.Success();
    }
}
