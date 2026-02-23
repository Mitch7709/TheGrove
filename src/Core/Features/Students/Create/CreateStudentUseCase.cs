using System;
using Core.Models;
using Core.Shared;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Students.Create;

public class CreateStudentUseCase(IDbContext dbContext)
{
    public async Task<Result<CreateStudentResponse>> ExecuteAsync(CreateStudentRequest request)
    {
        var exists = await dbContext.Set<Student>().AnyAsync(s => s.Email == request.Email);
        if (exists)
            return Result.Failure(ErrorType.Conflict, "A student already exists with the provided email");

        var student = new Student
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            DateOfBirth = request.DateOfBirth,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            ImageUrl = request.ImageUrl,
            WaiverStatus = WaiverStatus.NotSigned
        };
        student.Age = student.CalculateAge();

        dbContext.Set<Student>().Add(student);
        await dbContext.SaveChangesAsync();

        return new CreateStudentResponse
        (
            student.Id,
            student.FirstName,
            student.LastName,
            student.DateOfBirth,
            student.Email,
            student.PhoneNumber
        );
    }
}
