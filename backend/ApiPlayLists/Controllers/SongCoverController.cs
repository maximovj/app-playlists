using ApiPlayLists.Models;
using ApiPlayLists.Services;
using ApiPlayLists.Utils;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPlayLists.Controllers
{

    [Route("api/songs/cover")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class SongCoverController : ControllerBase
    {

        private readonly SongCoverService _service;
        
        private readonly SongService _songService;

        public SongCoverController(SongCoverService service, SongService songService)
        {
            _service = service;

            _songService = songService;
        }


        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm] SongCoverUploadDto dto)
        {
            try {

                if (!ModelState.IsValid)
                    return ApiResponse.BadRequest("Los parametos son incorrectos");

                if (dto.Cover == null || dto.Cover.Length == 0)
                    return ApiResponse.BadRequest("El archivo es obligatorio");

                if (!ValidFile.IsRealImage(dto.Cover))
                    return ApiResponse.BadRequest("El archivo debe ser una imagen valido");

                var song = await _songService.FindByIdAsync(dto.SongId);
                if (song == null)
                    return ApiResponse.NotFound("Entidad(Song) no encontrada");

                await _service.UploadSongCoverAsync(dto);

                return ApiResponse.Created("Entidad creada correctamente");

            } catch(DbUpdateException ex) {
                return ApiResponse.Conflict(ex.InnerException?.Message);
            } catch (InvalidOperationException ex) {
                return ApiResponse.Conflict(ex.InnerException?.Message);
            }

        }

        [HttpPut("{id:guid}/replace")]
        public async Task<IActionResult> Replace(Guid id, [FromForm] SongCoverUploadDto dto)
        {
            try
            {

                if (!ModelState.IsValid)
                    return ApiResponse.BadRequest("Los parametos son incorrectos");

                if (dto.Cover == null || dto.Cover.Length == 0)
                    return ApiResponse.BadRequest("El archivo es obligatorio");

                if (!ValidFile.IsRealImage(dto.Cover))
                    return ApiResponse.BadRequest("El archivo debe ser una imagen valido");

                var song = await _songService.FindByIdAsync(dto.SongId);
                if (song == null)
                    return ApiResponse.NotFound("Entidad(Song) no encontrada");

                var songCover = await _service.FindByIdAsync(id);
                if (songCover == null)
                    return ApiResponse.NotFound("Entidad(SongCover) no encontrada");

                await _service.ModifySongCoverAsync(dto, songCover);
                return ApiResponse.NotContent("Entidad modificada correctamente");
            } catch (DbUpdateException ex) {
                return ApiResponse.Conflict(ex.InnerException?.Message);
            } catch (InvalidOperationException ex) {
                return ApiResponse.Conflict(ex.InnerException?.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var songCover = await _service.FindByIdAsync(id);
            if (songCover == null)
                return ApiResponse.NotFound("Entidad no encontrada");

            await _service.RemoveSongCoverAsync(songCover);
            return ApiResponse.NotContent("Entidad eliminada correctamente");
        }
        
    }

}
