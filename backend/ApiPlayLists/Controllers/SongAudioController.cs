using ApiPlayLists.Models;
using ApiPlayLists.Services;
using ApiPlayLists.Utils;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPlayLists.Controllers
{
    [ApiController]
    [Route("api/songs/audio")]
    [EnableCors("AllowAll")]
    public class SongAudioController : ControllerBase
    {

        private readonly SongAudioService _songAudioService;
        
        private readonly SongService _songService;

        public SongAudioController(SongAudioService songAudioService, SongService songService)
        {
            _songAudioService = songAudioService;
            _songService = songService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadAudio([FromForm] SongAudioUploadDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return ApiResponse.BadRequest("Los parámetros son incorrectos", ModelState);

                if(dto.Audio == null || dto.Audio.Length == 0)
                    return ApiResponse.BadRequest("El archivo viene vacío", ModelState);

                if(!ValidFile.IsRealMp3(dto.Audio))
                    return ApiResponse.BadRequest("El archivo no es un MP3 válido", ModelState);

                var song = await _songService.FindByIdAsync(dto.SongId);
                if (song == null)
                    return ApiResponse.NotFound("Entidad(Song) no encontrada");

                await _songAudioService.UploadAudio(dto);
                return ApiResponse.Created("Entidad creada correctamente");

            }
            catch (DbUpdateException ex)
            {
                return ApiResponse.Conflict(ex.InnerException?.Message);
            }
        }

        [HttpPut("{id:guid}/replace")]
        public async Task<IActionResult> ReplaceAudio(Guid id, [FromForm] SongAudioUploadDto dto)
        {
            try {
                if (!ModelState.IsValid)
                    return ApiResponse.BadRequest("El cuerpo es incorrecto");

                if (dto.Audio == null || dto.Audio.Length == 0)
                    return ApiResponse.BadRequest("El archivo viene vacío", ModelState);

                if (!ValidFile.IsRealMp3(dto.Audio))
                    return ApiResponse.BadRequest("El archivo no es un MP3 válido", ModelState);

                var song = await _songService.FindByIdAsync(dto.SongId);
                if (song == null)
                    return ApiResponse.NotFound("Entidad(Song) no encontrada");

                var songAudio = await _songAudioService.FindByIdAsync(id);
                if (songAudio == null)
                    return ApiResponse.NotFound("Entidad(SongAudio) no encontrada");

                await _songAudioService.ReplaceAudio(dto, songAudio);

                return ApiResponse.NotContent("Entidad(SongAudio) modificada correctamente");
            } catch (DbUpdateException ex) {
                return ApiResponse.Conflict(ex.InnerException?.Message);
            }
        }

        [HttpDelete("{id:guid}/delete")]
        public async Task<IActionResult> DeleteAudio(Guid id)
        {
            var songAudio = await _songAudioService.FindByIdAsync(id);
            if (songAudio == null)
                return ApiResponse.NotFound("Entidad no encontrada");

            await _songAudioService.RemoveAudio(songAudio);
            return ApiResponse.NotContent("Entidad elimindad correctamente");
        }

    }
}
