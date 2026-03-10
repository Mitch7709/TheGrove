using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Features.Users.Login;

public class LoginUseCase(IUserService userService, ITokenService tokenService)
{
    public async Task<Result<LoginResponse>> Execute(LoginRequest request)
    {
        var user = await userService.Login(request.Email, request.Password);
        if (user == null)
            return Result.Failure(ErrorType.ValidationError, "Invalid email or password");

        var token = await tokenService.GenerateToken(user);

        return new LoginResponse(user.Id, token);
    }
}
