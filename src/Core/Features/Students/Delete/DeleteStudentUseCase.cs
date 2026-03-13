using System;
using Core.Models;
using Core.Shared;
using Microsoft.Identity.Client;

namespace Core.Features.Students.Delete;

public class DeleteStudentUseCase(IDbContext dbContext)
{
    public async Task<Result> ExecuteAsync(int id)
    {
        var student = await dbContext.Set<Student>().FindAsync(id);
        if (student is null)
        {
            return Result.Failure(ErrorType.NotFound, $"Student with id {id} not found.");
        }

        dbContext.Set<Student>().Remove(student);

        var appUser = await dbContext.Set<AppUser>().FindAsync(student.UserId);
        if (appUser is not null)
        {
            dbContext.Set<AppUser>().Remove(appUser);
        }        

        await dbContext.SaveChangesAsync();
        return Result.Success();
    }
}
