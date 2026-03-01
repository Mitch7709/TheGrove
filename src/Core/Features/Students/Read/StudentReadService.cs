using System;
using Core.Features.Students.Create;
using Core.Models;
using Core.Shared;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Students.Read;

public class StudentReadService(IDbContext dbContext)
{
    public async Task<IReadOnlyList<StudentResponse>> GetAllAsync()
    {
        return await dbContext.Set<Student>()
            .Select(s => new StudentResponse
            (
                s.Id,
                s.FirstName,
                s.LastName,
                s.PhoneNumber,
                s.Email
            ))
            .ToListAsync();
    }

    public async Task<Result<StudentResponse>> GetByIdAsync(int id)
    {
        var student = await dbContext.Set<Student>()
            .Where(s => s.Id == id)
            .Select(s => new StudentResponse
            (
                s.Id,
                s.FirstName,
                s.LastName,
                s.PhoneNumber,
                s.Email
            ))
            .FirstOrDefaultAsync();

        if (student is null)
        {
            return Result.Failure(ErrorType.NotFound, $"Student with id {id} not found.");
        }

        return student;
    }
}
