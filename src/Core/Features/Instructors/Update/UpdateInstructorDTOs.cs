using System;

namespace Core.Features.Instructors.Update;

public record UpdateInstructorRequest(
    string FirstName,
    string LastName,
    string PhoneNumber,
    string Email,
    string Bio,
    string ImageUrl
);

public record UpdateInstructorResponse(
    int Id,
    string FirstName,
    string LastName,
    string PhoneNumber,
    string Email,
    string Bio,
    string ImageUrl
);
