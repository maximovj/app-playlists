using System;
using ApiPlayLists.Entities;

namespace ApiPlayLists.Repositories;

public interface ISongAudioRepository
{

    Task<SongAudio?> FindByIdAsync(Guid id);

    Task SaveAsync(SongAudio songAudio);

    Task ModifyAsync(SongAudio songAudio);

    Task DeleteAsync(SongAudio songAudio);

}
