using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPlayLists.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "playlists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    UrlSlug = table.Column<string>(type: "text", nullable: false),
                    IsPublic = table.Column<bool>(type: "boolean", nullable: false),
                    CratedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_playlists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "playlist_covers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Img = table.Column<byte[]>(type: "bytea", nullable: false),
                    PlayListId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_playlist_covers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_playlist_covers_playlists_PlayListId",
                        column: x => x.PlayListId,
                        principalTable: "playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "songs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Artist = table.Column<string>(type: "text", nullable: true),
                    Genere = table.Column<string>(type: "text", nullable: true),
                    IsAvailableInSpotify = table.Column<bool>(type: "boolean", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: true),
                    Tags = table.Column<string>(type: "text", nullable: true),
                    PlayListId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_songs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_songs_playlists_PlayListId",
                        column: x => x.PlayListId,
                        principalTable: "playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "song_audios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Audio = table.Column<byte[]>(type: "bytea", nullable: false),
                    SongId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_song_audios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_song_audios_songs_SongId",
                        column: x => x.SongId,
                        principalTable: "songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "song_covers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Img = table.Column<byte[]>(type: "bytea", nullable: false),
                    SongId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_song_covers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_song_covers_songs_SongId",
                        column: x => x.SongId,
                        principalTable: "songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_playlist_covers_PlayListId",
                table: "playlist_covers",
                column: "PlayListId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_playlists_UrlSlug",
                table: "playlists",
                column: "UrlSlug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_song_audios_SongId",
                table: "song_audios",
                column: "SongId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_song_covers_SongId",
                table: "song_covers",
                column: "SongId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_songs_PlayListId",
                table: "songs",
                column: "PlayListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "playlist_covers");

            migrationBuilder.DropTable(
                name: "song_audios");

            migrationBuilder.DropTable(
                name: "song_covers");

            migrationBuilder.DropTable(
                name: "songs");

            migrationBuilder.DropTable(
                name: "playlists");
        }
    }
}
