using System;
using ApiPlayLists.Entities;

namespace ApiPlayLists.Repositories;

public interface ISongRepository
{

    Task<List<Song>> FindAllAsync();

    Task<Song?> FindByIdAsync(Guid id);

    Task AddAsync(Song entity);

    Task UpdateAsync(Song entity);

    Task DeleteAsync(Song entity);

}
