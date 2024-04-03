using Domain.Entities;
using FluentValidation;

namespace Application.Common.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(x => x.Email).NotEmpty()
            .WithMessage("Email can not be empty")
            .Length(6, 50)
            .EmailAddress();
        RuleFor(x => x.Password).NotEmpty()
            .WithMessage("Password can not be empty")
            .Length(6, 50)
            .WithMessage("Password should be between 6 and 50 characters");
        RuleFor(x => x.FirstName).NotEmpty()
            .WithMessage("Name is required");

    }
}
