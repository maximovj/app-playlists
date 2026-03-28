using System;
using ApiPlayLists.AppData;
using ApiPlayLists.Entities;

namespace ApiPlayLists.Repositories;

public class SongAudioRespositoryImpl : ISongAudioRepository
{

    private readonly AppDbContext _dbContext;

    public SongAudioRespositoryImpl(AppDbContext dbContext) => _dbContext = dbContext;

    public async Task<SongAudio?> FindByIdAsync(Guid id) => await _dbContext.SongAudios.FindAsync(id);

    public async Task DeleteAsync(SongAudio songAudio)
    {
        _dbContext.Remove(songAudio);
        await _dbContext.SaveChangesAsync();
    }

    public async Task ModifyAsync(SongAudio songAudio)
    {
        _dbContext.Update(songAudio);
        await _dbContext.SaveChangesAsync();
    }

    public async Task SaveAsync(SongAudio songAudio)
    {
        _dbContext.SongAudios.Add(songAudio);
        await _dbContext.SaveChangesAsync();
    }

}
