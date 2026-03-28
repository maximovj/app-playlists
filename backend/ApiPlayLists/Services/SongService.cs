using System;
using ApiPlayLists.Entities;
using ApiPlayLists.Mappers;
using ApiPlayLists.Models;
using ApiPlayLists.Repositories;

namespace ApiPlayLists.Services;

public class SongService
{

    private readonly ISongRepository _repository;

    public SongService(ISongRepository repository) => _repository = repository;

    public async Task<List<Song>> GetAll() => await _repository.FindAllAsync();
    public async Task<Song?> FindByIdAsync(Guid id) => await _repository.FindByIdAsync(id);

    public async Task<Song?> CreateSong(SongDto dto)
    {
        var entity = new Song()
        {
            Name = dto.Name,
            Artist = dto.Artist,
            Genere = dto.Genere,
            PlayListId = dto.PlayListId,
        };
        SongMapper.ApplyFilled(dto, entity);
        await _repository.AddAsync(entity);
        return entity;
    }

    public async Task<Song?> ModifySong(Guid id, SongDto dto)
    {
        var song = await _repository.FindByIdAsync(id);
        if (song == null) return null;

        SongMapper.ApplyFilled(dto, song);

        await _repository.UpdateAsync(song);
        return song;
    }

    public async Task<Song?> DeleteSong(Guid id) 
    {
        var song = await _repository.FindByIdAsync(id);
        if (song == null) return null;
        await _repository.DeleteAsync(song);
        return song;
    }

}
