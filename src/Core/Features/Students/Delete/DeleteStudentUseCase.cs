using System;
using Core.Models;
using Core.Shared;
using Microsoft.Identity.Client;

namespace Core.Features.Students.Delete;

public class DeleteStudentUseCase(IDbContext dbContext)
{
    public async Task<Result> ExecuteAsync(long id)
    {
        var student = await dbContext.Set<Student>().FindAsync(id);
        if (student is null)
        {
            return Result.Failure(ErrorType.NotFound, $"Student with id {id} not found.");
        }

        dbContext.Set<Student>().Remove(student);
        await dbContext.SaveChangesAsync();
        return Result.Success();
    }
}
