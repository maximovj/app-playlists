using System;
using System.ComponentModel.DataAnnotations;

namespace ApiPlayLists.Models;

public class SongCoverUploadDto
{

    [Required]
    public required Guid SongId { get; set; }

    [Required]
    public required IFormFile Cover { get; set; }

}
