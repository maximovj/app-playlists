using System;
using ApiPlayLists.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiPlayLists.AppData;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<PlayList> Playlists { get; set; }

    public DbSet<PlayListCover> PlayListCovers { get; set; }

    public DbSet<Song> Songs { get; set; }

    public DbSet<SongAudio> SongAudios { get; set; }

    public DbSet<SongCover> SongCovers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // // !! Entidad PlayList
            modelBuilder.Entity<PlayList>()
                .HasIndex(p => p.UrlSlug)
                .IsUnique();

            modelBuilder.Entity<PlayList>()
                .HasOne(p => p.Cover)
                .WithOne(c => c.PlayList)
                .HasForeignKey<PlayListCover>(pc => pc.PlayListId);

            // // !! Entidad PlayListCover
            modelBuilder.Entity<PlayListCover>()
                .HasIndex(pc => pc.PlayListId)
                .IsUnique();

            // // !! Entidad Song
            modelBuilder.Entity<Song>()
                .HasOne(s => s.Audio)
                .WithOne(a => a.Song)
                .HasForeignKey<SongAudio>(sa => sa.SongId);

            modelBuilder.Entity<Song>()
                .HasOne(s => s.Cover)
                .WithOne(c => c.Song)
                .HasForeignKey<SongCover>(sc => sc.SongId);

            
            // // !! Entidad SongAudio
            modelBuilder.Entity<SongAudio>()
                .HasIndex(sa => sa.SongId)
                .IsUnique();

            // // !! Entidad SongCover
            modelBuilder.Entity<SongCover>()
                .HasIndex(sc => sc.SongId)
                .IsUnique();

        }

}
