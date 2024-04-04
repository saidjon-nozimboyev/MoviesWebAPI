using Domain.Entities;
using FluentValidation;

namespace Application.Common.Validators;

public class MovieValidator : AbstractValidator<Movie>
{
    public MovieValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(100).WithMessage("Title cannot exceed 100 characters.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");

        RuleFor(x => x.Country)
            .NotEmpty().WithMessage("Country is required.")
            .MaximumLength(100).WithMessage("Country cannot exceed 100 characters.");

        RuleFor(x => x.Duration)
            .GreaterThan(0).WithMessage("Duration must be greater than 0.");

        RuleFor(x => x.Year)
            .InclusiveBetween(1900, DateTime.UtcNow.Year).WithMessage("Year must be between 1900 and current year.");

        RuleFor(x => x.Company)
            .NotEmpty().WithMessage("Company is required.")
            .MaximumLength(100).WithMessage("Company cannot exceed 100 characters.");

        RuleFor(x => x.Director)
            .NotEmpty().WithMessage("Director is required.")
            .MaximumLength(100).WithMessage("Director cannot exceed 100 characters.");

        RuleFor(x => x.GenreId)
            .GreaterThan(0).WithMessage("GenreId must be greater than 0.");
    }
}
