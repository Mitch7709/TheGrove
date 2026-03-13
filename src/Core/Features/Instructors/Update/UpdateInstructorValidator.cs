using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Features.Instructors.Update
{
    public class UpdateInstructorValidator : AbstractValidator<UpdateInstructorRequest>
    {
        public UpdateInstructorValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First name is required");
            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Last name is required");
            RuleFor(x => x.Email)
               .NotEmpty()
               .EmailAddress()
               .WithMessage("A valid email is required");
            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .Matches(@"^\d{3}-?\d{3}-?\d{4}$")
                .WithMessage("A valid phone number is required");
            RuleFor(x => x.Bio)
                .NotEmpty()
                .MaximumLength(500)
                .WithMessage("Bio cannot exceed 500 characters");
        }
    }
}
