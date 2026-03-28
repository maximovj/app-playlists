using System;
using ApiPlayLists.AppData;
using ApiPlayLists.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiPlayLists.Repositories;

public class SongRepositoryImpl : ISongRepository
{

    private readonly AppDbContext db_context;

    public SongRepositoryImpl(AppDbContext context) => db_context = context;

    public async Task<List<Song>> FindAllAsync() => await db_context.Songs.ToListAsync();

    public async Task<Song?> FindByIdAsync(Guid id) => await db_context.FindAsync<Song>([id]);

    public async Task AddAsync(Song entity)
    {
        db_context.Add(entity);
        await db_context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Song entity)
    {
        db_context.Update(entity);
        await db_context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Song entity)
    {
        db_context.Remove(entity);
        await db_context.SaveChangesAsync();
    }

}
