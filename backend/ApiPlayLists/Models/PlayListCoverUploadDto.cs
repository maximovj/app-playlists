using System;
using System.ComponentModel.DataAnnotations;

namespace ApiPlayLists.Models;

public class PlayListCoverUploadDto
{

    [Required]
    public required Guid PlayListId { get; set; }

    [Required]
    public required IFormFile Img {  get; set; }

}
