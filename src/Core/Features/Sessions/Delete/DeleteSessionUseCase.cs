using Core.Models;
using Core.Shared;

namespace Core.Features.Sessions.Delete;

public class DeleteSessionUseCase(IDbContext dbContext)
{
    public async Task<Result> ExecuteAsync(int id)
    {
        var session = await dbContext.Set<Session>().FindAsync(id);
        if (session is null)
        {
            return Result.Failure(ErrorType.NotFound, $"Session with id {id} not found.");
        }

        dbContext.Set<Session>().Remove(session);
        await dbContext.SaveChangesAsync();

        return Result.Success();
    }
}
