using System;
using ApiPlayLists.Entities;

namespace ApiPlayLists.Repositories;

public interface IPlayListRepository
{

    Task<List<PlayList>> FindAllAsync();

    Task<PlayList?> FindByIdAsync(Guid id);

    Task<PlayList?> FindByIdWithSongsAsync(Guid id);

    Task SaveAsync(PlayList entity);

    Task UpdateAsync(PlayList entity);

    Task RemoveAsync(PlayList entity);

}