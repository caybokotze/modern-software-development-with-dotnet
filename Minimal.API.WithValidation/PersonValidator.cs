using DWD.Shared;
using FluentValidation;

namespace Minimal.API.WithValidation;

public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {
        RuleFor(m => m.FirstName).NotEmpty().MinimumLength(5);
        RuleFor(m => m.LastName).NotEmpty().MinimumLength(5);
    }
}