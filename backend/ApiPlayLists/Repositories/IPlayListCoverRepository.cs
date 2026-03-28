using System;
using ApiPlayLists.Entities;

namespace ApiPlayLists.Repositories;

public interface IPlayListCoverRepository
{

    Task<PlayListCover?> FindByIdAsync(Guid id);

    Task AddAsync(PlayListCover cover);

    Task UpdateAsync(PlayListCover cover);

    Task RemoveAsync(PlayListCover cover);

}