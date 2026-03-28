using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPlayLists.Entities;

[Table("playlists")]
public class PlayList
{

    public Guid Id { get; set; } = Guid.NewGuid();

        public required String Name { get; set; }

        public String? Description { get; set; } = null;

        public PlayListCover? Cover { get; set; } = null;

        public required string UrlSlug { get; set; }

        public bool IsPublic { get; set; } = true;

        public DateTime CratedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdateAt { get; set; } = DateTime.UtcNow;

        // relación ManyToMany
        public ICollection<Song> Songs { get; set; } = [];

}
