using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiPlayLists.Entities;

[Table("song_covers")]
public class SongCover
{

    public Guid Id { get; set; } = Guid.NewGuid();

    public required byte[] Img { get; set; }

        // Clave foránea y clave inversa (relación OneToOne)
    public required Guid SongId { get; set; }

    [JsonIgnore]
    [ForeignKey(nameof(SongId))]
    public Song? Song { get; set; } = null;

}
