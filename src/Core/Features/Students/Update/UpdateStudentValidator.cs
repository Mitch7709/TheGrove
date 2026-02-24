using System;
using Core.Models;
using FluentValidation;

namespace Core.Features.Students.Update;

public class UpdateStudentValidator : AbstractValidator<UpdateStudentRequest>
{
    public UpdateStudentValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(Student.MaxLength.FirstName);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(Student.MaxLength.LastName);

        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .MaximumLength(Student.MaxLength.PhoneNumber);

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(Student.MaxLength.Email);

        RuleFor(x => x.DateOfBirth)
            .LessThan(DateOnly.FromDateTime(DateTime.Today))
            .WithMessage("Date of birth must be in the past");

        RuleFor(x => x.Age)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Age must be a non-negative number");
    }
}
