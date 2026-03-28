using System;
using ApiPlayLists.Entities;
using ApiPlayLists.Models;

namespace ApiPlayLists.Mappers;

public class SongMapper
{
    public static void ApplyFilled(SongDto dto, Song song) 
    {
        if (!Object.Equals(dto.PlayListId, null)) song.PlayListId = dto.PlayListId;
        if (dto.Name != null) song.Name = dto.Name;
        if (dto.Artist != null) song.Artist = dto.Artist;
        if (dto.Genere != null) song.Genere = dto.Genere;
        if (dto.Price != null) song.Price = dto.Price.Value;
        if (dto.Tags != null) song.Tags = dto.Tags;
        if (!Object.Equals(dto.IsAvailableInSpotify, null))
            song.IsAvailableInSpotify = dto.IsAvailableInSpotify;
    }
    
}
