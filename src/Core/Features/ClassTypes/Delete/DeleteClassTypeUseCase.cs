using System.Threading.Tasks;
using Core.Models;
using Core.Shared;

namespace Core.Features.ClassTypes.Delete;

public class DeleteClassTypeUseCase(IDbContext dbContext)
{
    public async Task<Result> ExecuteAsync(int id)
    {
        var classType = await dbContext.Set<ClassType>().FindAsync(id);
        if (classType is null)
        {
            return Result.Failure(ErrorType.NotFound, $"ClassType with id {id} not found.");
        }

        dbContext.Set<ClassType>().Remove(classType);
        await dbContext.SaveChangesAsync();

        return Result.Success();
    }
}
