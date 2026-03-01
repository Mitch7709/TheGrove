using System;
using Core.Models;
using Core.Shared;

namespace Core.Features.Students.Update;

public class UpdateStudentUseCase(IDbContext dbContext)
{
    public async Task<Result<UpdateStudentResponse>> ExecuteAsync(int studentId, UpdateStudentRequest request)
    {
        var student = await dbContext.Set<Student>().FindAsync(studentId);
        if (student is null)
            return Result.Failure(ErrorType.NotFound, $"Student with id {studentId} was not found");

        student.FirstName = request.FirstName;
        student.LastName = request.LastName;
        student.PhoneNumber = request.PhoneNumber;
        student.Email = request.Email;
        student.DateOfBirth = request.DateOfBirth;
        student.Age = request.Age;
        student.ImageUrl = request.ImageUrl;
        student.WaiverStatus = request.WaiverStatus;

        await dbContext.SaveChangesAsync();

        return new UpdateStudentResponse(
            student.Id,
            student.FirstName,
            student.LastName,
            student.PhoneNumber,
            student.Email,
            student.DateOfBirth,
            student.Age,
            student.ImageUrl,
            student.WaiverStatus
        );
    }
}
