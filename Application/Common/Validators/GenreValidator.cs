using Domain.Entities;
using FluentValidation;

namespace Application.Common.Validators;

public class GenreValidator : AbstractValidator<Genre>
{
    public GenreValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name can not be empty")
            .Length(3,20)
            .WithMessage("Name should be between 3 abd 20 characters");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description can not be empty");

    }
}
