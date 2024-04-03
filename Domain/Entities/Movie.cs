using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Movie : Base
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public int Duration { get; set; }
    public int Year { get; set; }
    public string Company { get; set; } = string.Empty;
    public string Director { get; set; } = string.Empty;
    public int GenreId { get; set; }

    [ForeignKey(nameof(GenreId))]
    public Genre Genre { get; set; } = null!;
}
