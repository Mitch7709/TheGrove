using Core.Shared;
using System.Security.Claims;

namespace API.Shared
{
    public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
    {
        public string? GetUserId()
        {
            var claimsPrincipal = httpContextAccessor
                .HttpContext?
                .User ??
                throw new ApplicationException("User context is not available.");

            return claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        public bool IsAuthenticated()
        {
            return httpContextAccessor
                .HttpContext?
                .User
                .Identity?
                .IsAuthenticated ??
                throw new ApplicationException("User context is not available.");
        }
    }
}
