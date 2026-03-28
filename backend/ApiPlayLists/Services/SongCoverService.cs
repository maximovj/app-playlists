using System;
using ApiPlayLists.Entities;
using ApiPlayLists.Models;
using ApiPlayLists.Repositories;

namespace ApiPlayLists.Services;

public class SongCoverService
{

    private readonly ISongCoverRepository _repository;

    public SongCoverService(ISongCoverRepository repository) => _repository = repository;

    public async Task<SongCover?> FindByIdAsync(Guid id) => await _repository.FindByIdAsync(id);

    public async Task<SongCover?> UploadSongCoverAsync(SongCoverUploadDto dto)
    {
        using var ms = new MemoryStream();
        await dto.Cover.CopyToAsync(ms);

        var songCover = new SongCover()
        {
            Img = ms.ToArray(),
            SongId = dto.SongId,
        };

        await _repository.SaveAsync(songCover);
        return songCover;
    }

    public async Task<SongCover?> ModifySongCoverAsync(SongCoverUploadDto dto, SongCover songCover)
    {
        using var ms = new MemoryStream();
        await dto.Cover.CopyToAsync(ms);
        songCover.Img = ms.ToArray();

        await _repository.UpdateAsync(songCover);
        return songCover;
    }

    public async Task<SongCover?> RemoveSongCoverAsync(SongCover songCover)
    {
        await _repository.RemoveAsync(songCover);
        return songCover;
    }

}
