using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiPlayLists.Entities;

[Table("playlist_covers")]
public class PlayListCover
{

    public Guid Id { get; set; } = Guid.NewGuid();

    public required byte[] Img { get; set; }

        // Clave Foranea y relación inversa (realción OneToOne)
    public Guid PlayListId { get; set;  }

    [JsonIgnore]
    [ForeignKey(nameof(PlayListId))] 
    public PlayList? PlayList { get; set; }

}
