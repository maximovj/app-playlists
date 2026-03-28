using System;
using ApiPlayLists.Entities;
using ApiPlayLists.Models;
using ApiPlayLists.Repositories;

namespace ApiPlayLists.Services;

public class SongAudioService
{

    private readonly ISongAudioRepository _repository;

    public SongAudioService(ISongAudioRepository repository) => _repository = repository;

    public async Task<SongAudio?> FindByIdAsync(Guid id) => await _repository.FindByIdAsync(id);

    public async Task<SongAudio?> UploadAudio(SongAudioUploadDto dto)
    {
        using var ms = new MemoryStream();
        await dto.Audio.CopyToAsync(ms);

        var songAudio = new SongAudio()
        {
            Audio = ms.ToArray(),
            SongId = dto.SongId,
        };

        await _repository.SaveAsync(songAudio);
        return songAudio;
    }

    public async Task<SongAudio?> ReplaceAudio(SongAudioUploadDto dto, SongAudio songAudio)
    {
        using var ms = new MemoryStream();
        await dto.Audio.CopyToAsync(ms);
        songAudio.Audio = ms.ToArray();

        await _repository.ModifyAsync(songAudio);
        return songAudio;
    }

    public async Task<SongAudio?> RemoveAudio(SongAudio songAudio) 
    {
        await _repository.DeleteAsync(songAudio);
        return songAudio;
    }

}
