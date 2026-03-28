using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiPlayLists.Entities;

[Table("songs")]
public class Song
{

    public Guid Id { get; set; } = Guid.NewGuid();

    public required string? Name { get; set; }

    public required string? Artist { get; set; }

    public required string? Genere { get; set; }

    public bool IsAvailableInSpotify { get; set; } = false;

    public decimal? Price { get; set; } = 0.0m;

    public string? Tags { get; set; } = "";

        // relación OneToOne
    public SongAudio? Audio { get; set; }

        // relación OneToOne
    public SongCover? Cover { get; set; }

        // Clave foránea y relación inversa (relación ManyToMany)
    public required Guid PlayListId { get; set; }

    [JsonIgnore]
    [ForeignKey(nameof(PlayListId))]
    public PlayList? PlayList { get; set; } = null;

}
