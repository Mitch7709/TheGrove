using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using Core.Shared;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.ClassTypes.Create;

public class CreateClassTypeUseCase(IDbContext dbContext)
{
    public async Task<Result<CreateClassTypeResponse>> ExecuteAsync(CreateClassTypeRequest request)
    {
        var exists = await dbContext.Set<ClassType>()
            .AnyAsync(ct => ct.Name == request.Name);

        if (exists)
            return Result.Failure(ErrorType.Conflict, $"A class type with the name '{request.Name}' already exists.");

        var instructors = await dbContext.Set<Instructor>()
            .Where(i => request.QualifiedInstructorIds.Contains(i.Id))
            .ToListAsync();

        if (instructors.Count != request.QualifiedInstructorIds.Count)
            return Result.Failure(ErrorType.ValidationError, "One or more instructor IDs are invalid.");

        var classType = new ClassType
        {
            Name = request.Name,
            Description = request.Description,
            Style = request.Style,
            Level = request.Level,
            IsActive = request.IsActive
        };

        foreach (var instructor in instructors)
            classType.QualifiedInstructors.Add(instructor);

        dbContext.Set<ClassType>().Add(classType);
        await dbContext.SaveChangesAsync();

        return new CreateClassTypeResponse(
            classType.Id,
            classType.Name,
            classType.Description,
            classType.Style,
            classType.Level,
            classType.IsActive
        );
    }
}
