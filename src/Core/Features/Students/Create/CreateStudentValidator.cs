using Core.Models;
using FluentValidation;

namespace Core.Features.Students.Create
{
    public class CreateStudentValidator : AbstractValidator<CreateStudentRequest>
    {
        public CreateStudentValidator() 
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(Student.MaxLength.FirstName);
            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(Student.MaxLength.LastName);
            RuleFor(x => x.DateOfBirth)
                .NotEmpty();
            RuleFor(x => x.Email)
                .NotEmpty()
                .MaximumLength(Student.MaxLength.Email);
            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .MaximumLength(Student.MaxLength.PhoneNumber);
        }
    }
}
