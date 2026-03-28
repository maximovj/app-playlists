using System;
using Slugify;
using ApiPlayLists.Entities;
using ApiPlayLists.Mappers;
using ApiPlayLists.Models;
using ApiPlayLists.Repositories;

namespace ApiPlayLists.Services;

public class PlayListService
{

    private readonly IPlayListRepository _repository;

    public PlayListService(IPlayListRepository repository) => _repository = repository;

    public async Task<List<PlayList>> FindAllAsync() => await _repository.FindAllAsync();

    public async Task<PlayList?> FindByIdAsync(Guid id) => await _repository.FindByIdAsync(id);

    public async Task<PlayList?> FindByIdWithSongsAsync(Guid id) => await _repository.FindByIdWithSongsAsync(id);

    public async Task<PlayList?> CreateAsync(PlayListDto dto)
    {
        // Crear entidad y rellenar
        var entity = new PlayList()
        {
            Name = dto.Name,
            UrlSlug = new SlugHelper().GenerateSlug(dto.Name),
        };
        PlayListMapper.Filled(dto, entity);

        await _repository.SaveAsync(entity);
        return entity;
    }

    public async Task<PlayList?> ModifyAsync(PlayListDto dto, PlayList playlist)
    {
        // Actualizar la entidad
        PlayListMapper.Filled(dto, playlist);
        await _repository.UpdateAsync(playlist);
        return playlist;
    }

    public async Task<PlayList?> RemoveAsync(PlayList playlist)
    {
        await _repository.RemoveAsync(playlist);
        return playlist;
    }

}
