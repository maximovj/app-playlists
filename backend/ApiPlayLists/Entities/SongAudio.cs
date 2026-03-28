using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiPlayLists.Entities;

[Table("song_audios")]
public class SongAudio
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public required byte[] Audio { get; set; }

        // Clave foránea y clave inversa (relación OneToOne)
    public Guid SongId { get; set; }

    [JsonIgnore]
    [ForeignKey(nameof(SongId))]
    public Song? Song { get; set; } = null;

}
