using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using Core.Shared;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.ClassTypes.Read;

public class ClassTypeReadService(IDbContext dbContext)
{
    public async Task<IReadOnlyList<ClassTypeResponse>> GetAllAsync()
    {
        return await dbContext.Set<ClassType>()
            .Include(ct => ct.QualifiedInstructors)
                .ThenInclude(i => i.AppUser)
            .Select(c => new ClassTypeResponse
            (
                c.Id,
                c.Name,
                c.Description,
                c.Style,
                c.Level,
                c.IsActive,
                c.QualifiedInstructors.Select(i => new QualifiedInstructorSummary
                (
                    i.Id,
                    i.AppUser.FirstName,
                    i.AppUser.LastName
                )).ToList()
            ))
            .ToListAsync();
    }

    public async Task<Result<ClassTypeResponse>> GetByIdAsync(int id)
    {
        var classType = await dbContext.Set<ClassType>()
            .Include(ct => ct.QualifiedInstructors)
                .ThenInclude(i => i.AppUser)
            .Where(c => c.Id == id)
            .Select(c => new ClassTypeResponse
            (
                c.Id,
                c.Name,
                c.Description,
                c.Style,
                c.Level,
                c.IsActive,
                c.QualifiedInstructors.Select(i => new QualifiedInstructorSummary
                (
                    i.Id,
                    i.AppUser.FirstName,
                    i.AppUser.LastName
                )).ToList()
            ))
            .FirstOrDefaultAsync();

        if (classType is null)
            return Result.Failure(ErrorType.NotFound, $"ClassType with id {id} not found.");

        return classType;
    }
}
