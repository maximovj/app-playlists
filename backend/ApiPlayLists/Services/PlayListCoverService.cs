using System;
using ApiPlayLists.Entities;
using ApiPlayLists.Models;
using ApiPlayLists.Repositories;

namespace ApiPlayLists.Services;

public class PlayListCoverService
{

    private readonly IPlayListCoverRepository _repository;

    public PlayListCoverService(IPlayListCoverRepository repository) => _repository = repository;

    public async Task<PlayListCover?> FindByIdAsync(Guid id) => await _repository.FindByIdAsync(id);

    public async Task<PlayListCover?> UploadImgAsync(PlayListCoverUploadDto dto)
    {
        using var ms = new MemoryStream();
        await dto.Img.CopyToAsync(ms);

        var playListCover = new PlayListCover
        {
            Img = ms.ToArray(),
            PlayListId = dto.PlayListId,
        };

        await _repository.AddAsync(playListCover);
        return playListCover;
    }

    public async Task<PlayListCover?> ReplaceImgAsync(PlayListCoverUploadDto dto, PlayListCover playListCover)
    {
        using var ms = new MemoryStream();
        await dto.Img.CopyToAsync(ms);

        playListCover.Img = ms.ToArray();

        await _repository.UpdateAsync(playListCover);
        return playListCover;
    }

    public async Task<PlayListCover?> RemoveImgAsync(PlayListCover playListCover)
    {
        await _repository.RemoveAsync(playListCover);
        return playListCover;
    }

}
