using System;
using Core.Models;
using Core.Shared;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Instructors.Read;

public class InstructorReadService(IDbContext dbContext)
{
    public async Task<IReadOnlyList<InstructorResponse>> GetAllAsync()
    {
        return await dbContext.Set<Instructor>()
            .Include(i => i.AppUser)
            .Select(i => new InstructorResponse
            (
                i.Id,
                i.AppUser.FirstName,
                i.AppUser.LastName,
                i.AppUser.PhoneNumber,
                i.AppUser.Email
            ))
            .ToListAsync();
    }

    public async Task<Result<InstructorResponse>> GetByIdAsync(int id)
    {
        var instructor = await dbContext.Set<Instructor>()
            .Include(i => i.AppUser)
            .Where(i => i.Id == id)
            .Select(i => new InstructorResponse
            (
                i.Id,
                i.AppUser.FirstName,
                i.AppUser.LastName,
                i.AppUser.PhoneNumber,
                i.AppUser.Email
            ))
            .FirstOrDefaultAsync();

        if (instructor is null)
        {
            return Result.Failure(ErrorType.NotFound, $"Instructor with id {id} not found.");
        }

        return instructor;
    }
}
