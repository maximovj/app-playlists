using System;
using System.ComponentModel.DataAnnotations;

namespace ApiPlayLists.Models;

public class SongAudioUploadDto
{

    [Required]
    public required Guid SongId { get; set; }

    [Required]
    public required IFormFile Audio { get; set; }

}
