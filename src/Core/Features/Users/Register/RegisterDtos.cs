using System;

namespace Core.Features.Users.Register
{
    public record RegisterRequest(
        string FirstName,
        string LastName,
        string Email,
        string PhoneNumber,
        DateOnly DateOfBirth,
        string? Bio,
        string? ImageUrl,
        string Password
        );

    public record RegisterResponse(
        string UserId,
        string Token
    );
}
