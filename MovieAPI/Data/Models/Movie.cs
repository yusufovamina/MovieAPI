using System;
using System.Collections.Generic;

namespace MovieAPI.Data.Models;

public partial class Movie
{
    public int MovieId { get; set; }

    public string Title { get; set; } = null!;

    public int? ReleaseYear { get; set; }

    public string? Director { get; set; }

    public string? Description { get; set; }

    public decimal? Rating { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }
}
