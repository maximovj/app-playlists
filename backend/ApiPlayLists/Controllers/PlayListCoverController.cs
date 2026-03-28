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
    [Route("api/playlists/cover")]
    [EnableCors("AllowAll")]
    public class PlayListCoverController : ControllerBase
    {

        private readonly PlayListCoverService _service;
        
        public readonly PlayListService _playListService;

        public PlayListCoverController(PlayListCoverService service, PlayListService playListService)
        {
            _service = service;
            _playListService = playListService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImg([FromForm] PlayListCoverUploadDto dto)
        {
            try {
                if (!ModelState.IsValid)
                    return ApiResponse.BadRequest("Los parámetros son incorrectos", ModelState);

                if (!ValidFile.IsRealImage(dto.Img))
                    return ApiResponse.BadRequest("El archivo no es una imágen");

                var playList = await _playListService.FindByIdAsync(dto.PlayListId);
                if (playList == null)
                    return ApiResponse.BadRequest("Entidad(PlayList) no encontrada");

                await _service.UploadImgAsync(dto);
                return ApiResponse.Created("Entidad creada correctamente");
            } catch(DbUpdateException ex) {
                return ApiResponse.Conflict(ex.InnerException?.Message);
            }
        }

        [HttpPut("{id:guid}/replace")]
        public async Task<IActionResult> ReplaceImg(Guid id, [FromForm] PlayListCoverUploadDto dto)
        {
            try {

                if (!ModelState.IsValid)
                    return ApiResponse.BadRequest("Los parámetros son incorrectos", ModelState);

                if (!ValidFile.IsRealImage(dto.Img))
                    return ApiResponse.BadRequest("El archivo no es una imágen");

                var playList = await _playListService.FindByIdAsync(dto.PlayListId);
                if (playList == null)
                    return ApiResponse.BadRequest("Entidad(PlayList) no encontrada");

                var playListCover = await _service.FindByIdAsync(id);
                if (playListCover == null)
                    return ApiResponse.BadRequest("Entidad no encontrada");

                await _service.ReplaceImgAsync(dto, playListCover);
                return ApiResponse.NotContent("Entidad modificada correctamente");
            } catch (DbUpdateException ex) {
                return ApiResponse.Conflict(ex.InnerException?.Message);
            }
        }

        [HttpDelete("{id:guid}/delete")]
        public async Task<IActionResult> RemoveImg(Guid id)
        {
            var playListCover = await _service.FindByIdAsync(id);
            if (playListCover == null)
                return ApiResponse.BadRequest("Entidad no encontrada");

            await _service.RemoveImgAsync(playListCover);
            return ApiResponse.NotContent("Entidad eliminada correctamente");
        }

    }
}
