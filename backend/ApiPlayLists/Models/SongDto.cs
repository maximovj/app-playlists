using System;
using System.ComponentModel.DataAnnotations;

namespace ApiPlayLists.Models;

public class SongDto
{

    [Required, MaxLength(100)]
    public required string? Name { get; set; }

    [Required, MaxLength(100)]
    public required string? Artist { get; set; }

    [Required, MaxLength(100)]
    public required string? Genere { get; set; }

    public bool IsAvailableInSpotify { get; set; } = false;

    public decimal? Price { get; set; } = 0.0m;
    
    public string? Tags { get; set; } = "";

    public required Guid PlayListId { get; set; }

}
