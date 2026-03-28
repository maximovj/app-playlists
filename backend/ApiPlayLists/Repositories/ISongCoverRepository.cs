using System;
using ApiPlayLists.Entities;

namespace ApiPlayLists.Repositories;

public interface ISongCoverRepository
{

    Task<SongCover?> FindByIdAsync(Guid id);

    Task SaveAsync(SongCover songCover);

    Task UpdateAsync(SongCover songCover);

    Task RemoveAsync(SongCover songCover);

}
