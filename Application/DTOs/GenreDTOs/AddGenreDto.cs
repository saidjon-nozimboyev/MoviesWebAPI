using Domain.Entities;

namespace Application.DTOs.GenreDTOs;

public class AddGenreDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public static implicit operator Genre(AddGenreDto dto)
    {
        return new Genre()
        {
            Name = dto.Name,
            Description = dto.Description
        };
    }
}
