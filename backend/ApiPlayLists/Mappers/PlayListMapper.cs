using System;
using ApiPlayLists.Entities;
using ApiPlayLists.Models;

namespace ApiPlayLists.Mappers;

public class PlayListMapper
{

    public static void Filled(PlayListDto dto, PlayList playlist)
    {
        if (dto.Name != null)
            playlist.Name = dto.Name;
        if (dto.Description != null)
            playlist.Description = dto.Description;
        if (dto.UrlSlug != null)
            playlist.UrlSlug = dto.UrlSlug;
        if (!Object.Equals(dto.IsPublic, null))
            playlist.IsPublic = dto.IsPublic;
    }

}
