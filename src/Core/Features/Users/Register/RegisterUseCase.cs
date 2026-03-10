using Core.Models;
using Core.Features.Students.Create;
using Core.Features.Instructors.Create;

namespace Core.Features.Users.Register;

public class RegisterUseCase(
    IUserService userService,
    ITokenService tokenService,
    CreateStudentUseCase createStudentUseCase,
    CreateInstructorUseCase createInstructorUseCase)
{
    public async Task<Result<RegisterResponse>> Execute(RegisterRequest request)
    {
        var existingUser = await userService.FindByEmail(request.Email);
        if (existingUser != null)
        {
            return Result.Failure(ErrorType.ValidationError, "User already exists with this email.");
        }

        var user = new AppUser
        (
            request.Email,
            request.FirstName,
            request.LastName,
            request.PhoneNumber
        );

        var result = await userService.Register(user, request.Password, request.Role);
        if (result.IsFailure)
        {
            return Result.Failure(result.ErrorType.Value, result.ErrorMessage);
        }

        switch (request.Role)
        {
            case UserRole.Student:
                var studentRequest = new CreateStudentRequest(user.Id, request.DateOfBirth, request.ImageUrl);
                await createStudentUseCase.ExecuteAsync(studentRequest);
                break;
            case UserRole.Instructor:
                var instructorRequest = new CreateInstructorRequest(user.Id, request.Bio, request.ImageUrl);
                await createInstructorUseCase.ExecuteAsync(instructorRequest);
                break;
        }

        var token = await tokenService.GenerateToken(user);

        return new RegisterResponse(user.Id, token);
    }
}
