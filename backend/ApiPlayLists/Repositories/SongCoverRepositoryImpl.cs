using System;
using ApiPlayLists.AppData;
using ApiPlayLists.Entities;

namespace ApiPlayLists.Repositories;

public class SongCoverRepositoryImpl
{

    private readonly AppDbContext _dbContext;

    public SongCoverRepositoryImpl(AppDbContext dbContext) => _dbContext = dbContext;

    public async Task<SongCover?> FindByIdAsync(Guid id) => await _dbContext.SongCovers.FindAsync(id);

    public async Task RemoveAsync(SongCover songCover)
    {
        _dbContext.Remove(songCover);
        await _dbContext.SaveChangesAsync();
    }

    public async Task SaveAsync(SongCover songCover)
    {
        _dbContext.Add(songCover);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(SongCover songCover)
    {
        _dbContext.Update(songCover);
        await _dbContext.SaveChangesAsync();
    }

}
