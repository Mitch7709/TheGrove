using System;

namespace Core.Features.Students.Read;

public record StudentResponse (
    int Id,
    string FirstName,
    string LastName,
    string PhoneNumber,
    string Email,
    DateOnly? DateOfBirth
);
