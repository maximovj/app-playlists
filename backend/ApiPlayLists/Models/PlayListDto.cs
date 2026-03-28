using System;
using System.ComponentModel.DataAnnotations;

namespace ApiPlayLists.Models;

public class PlayListDto
{

    [Required, MaxLength(100)]
    public required String Name { get; set; }

    [MaxLength(500)]
    public String? Description { get; set; } = null;

    public String? UrlSlug { get; set; } = null;

    public bool IsPublic { get; set; } = true;

}
