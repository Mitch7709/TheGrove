using System;
using Core.Models;

namespace Core.Features.Students.Update;

public record UpdateStudentRequest(
    string FirstName,
    string LastName,
    string PhoneNumber,
    string Email,
    DateOnly DateOfBirth,
    int Age,
    string ImageUrl,
    WaiverStatus WaiverStatus
);

public record UpdateStudentResponse(
    long Id,
    string FirstName,
    string LastName,
    string PhoneNumber,
    string Email,
    DateOnly DateOfBirth,
    int Age,
    string ImageUrl,
    WaiverStatus WaiverStatus
);
