using System;

namespace Core.Features.Students.Create;

public record CreateStudentRequest(
    string FirstName,
    string LastName,
    DateOnly DateOfBirth,
    string Email,
    string PhoneNumber,
    string ImageUrl
);

public record CreateStudentResponse(
    int Id,
    string FirstName,
    string LastName,
    DateOnly DateOfBirth,
    string Email,
    string PhoneNumber
);
