using System;
using ApiPlayLists.AppData;
using ApiPlayLists.Entities;

namespace ApiPlayLists.Repositories;

public class PlayListCoverImpl : IPlayListCoverRepository
{

    private readonly AppDbContext _dbContext;
        public PlayListCoverImpl(AppDbContext dbContext) => _dbContext = dbContext;

        public async Task<PlayListCover?> FindByIdAsync(Guid id) => await _dbContext.PlayListCovers.FindAsync(id);

        public async Task AddAsync(PlayListCover playlistCover)
        {
            _dbContext.Add(playlistCover);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(PlayListCover playlistCover)
        {
            _dbContext.Remove(playlistCover);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(PlayListCover playlistCover)
        {
            _dbContext.Update(playlistCover);
            await _dbContext.SaveChangesAsync();
        }

}
