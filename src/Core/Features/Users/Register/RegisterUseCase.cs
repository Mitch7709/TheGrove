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
    public async Task<Result<RegisterResponse>> Execute(RegisterRequest request, UserRole role)
    {
        var existingUser = await userService.FindByEmail(request.Email);
        if (existingUser != null)
        {
            return Result.Failure(ErrorType.ValidationError, "User already exists with this email.");
        }

        switch (role)
        {
            case UserRole.Student:
                if (request.DateOfBirth is null)
                {
                    return Result.Failure(ErrorType.ValidationError, "Date of birth is required for students.");
                }
                break;
            case UserRole.Instructor:
                if (request.Bio is null)
                {
                    return Result.Failure(ErrorType.ValidationError, "Bio is required for instructors.");
                }
                break;
        }

        var user = new AppUser
        (
            request.Email,
            request.FirstName,
            request.LastName,
            request.PhoneNumber
        );

        var result = await userService.Register(user, request.Password, role);
        if (result.IsFailure)
        {
            return Result.Failure(result.ErrorType.Value, result.ErrorMessage);
        }

        switch (role)
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
