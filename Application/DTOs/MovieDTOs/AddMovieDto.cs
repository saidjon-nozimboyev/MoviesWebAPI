using Domain.Entities;

namespace Application.DTOs.MovieDTOs;

public class AddMovieDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public int Duration { get; set; }
    public int Year { get; set; }
    public string Company { get; set; } = string.Empty;
    public string Director { get; set; } = string.Empty;
    public int GenreId { get; set; }

    public static implicit operator Movie(AddMovieDto dto)
    {
        return new Movie
        {
            Title = dto.Title,
            Description = dto.Description,
            Country = dto.Country,
            Director = dto.Director,
            GenreId = dto.GenreId,
            Duration = dto.Duration,
            Year = dto.Year,
            Company = dto.Company
        };
    }
}
