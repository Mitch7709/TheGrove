using System;

namespace Core.Features.Students.Read;

public record StudentResponse (
    long Id,
    string firstName,
    string lastName,
    string phoneNumber,
    string email
);
