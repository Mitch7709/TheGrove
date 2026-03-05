using System;

namespace Core.Features.Instructors.Read;

public record InstructorResponse(
    int Id,
    string firstName,
    string lastName,
    string phoneNumber,
    string email
);
