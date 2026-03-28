using System;
using ApiPlayLists.AppData;
using ApiPlayLists.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiPlayLists.Repositories;

public class PlayListRepositoryImpl : IPlayListRepository
{

    private readonly AppDbContext _dbContext;

    public PlayListRepositoryImpl(AppDbContext dbContext) => _dbContext = dbContext;

    public async Task AddAsync(PlayList playList)
    {
        _dbContext.Add(playList);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<PlayList>> FindAllAsync() => await _dbContext.Playlists.ToListAsync();

    public async Task<PlayList?> FindByIdAsync(Guid id) => await _dbContext.Playlists.FindAsync(id);

    public async Task<PlayList?> FindByIdWithSongsAsync(Guid id)
    {
        return await _dbContext
            .Playlists
            .Include(p => p.Songs)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task RemoveAsync(PlayList entity)
    {
        _dbContext.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task SaveAsync(PlayList entity)
    {
        _dbContext.Add(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(PlayList entity)
    {
        _dbContext.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

}
