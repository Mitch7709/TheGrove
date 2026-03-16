using System.Threading.Tasks;
using Core.Models;
using Core.Shared;

namespace Core.Features.ClassTypes.Update;

public class UpdateClassTypeUseCase(IDbContext dbContext)
{
    public async Task<Result<UpdateClassTypeResponse>> ExecuteAsync(int classTypeId, UpdateClassTypeRequest request)
    {
        var classType = await dbContext.Set<ClassType>().FindAsync(classTypeId);

        if (classType is null)
            return Result.Failure(ErrorType.NotFound, $"ClassType with id {classTypeId} was not found");

        classType.Name = request.Name;
        classType.Description = request.Description;
        classType.Style = request.Style;
        classType.Level = request.Level;
        classType.IsActive = request.IsActive;

        await dbContext.SaveChangesAsync();

        return new UpdateClassTypeResponse(
            classType.Id,
            classType.Name,
            classType.Description,
            classType.Style,
            classType.Level,
            classType.IsActive
        );
    }
}
