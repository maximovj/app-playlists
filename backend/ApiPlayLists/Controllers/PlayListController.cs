using ApiPlayLists.Models;
using ApiPlayLists.Services;
using ApiPlayLists.Utils;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPlayLists.Controllers
{
    [ApiController]
    [Route("api/playlists")]
    [EnableCors("AllowAll")]
    public class PlayListController : ControllerBase
    {
        
        private readonly PlayListService _service;

        public PlayListController(PlayListService service) => _service = service;

        [HttpGet("testing")]
        public async Task<IActionResult> GetTesting([FromBody] PlayListDto dto)
        {
            return ApiResponse.Success("Cuerpo recibido", dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PlayListDto dto)
        {
            var playlist = await _service.CreateAsync(dto);
            if (playlist == null)
                return ApiResponse.NotContent("Entidad no creado");

            return ApiResponse.Created("Entidad creada correctamente", playlist);
        }

        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] PlayListDto dto)
        {
            var playlist = await _service.FindByIdAsync(id);
            if (playlist == null)
                return ApiResponse.NotFound("Entidad no encontrada");

            await _service.ModifyAsync(dto, playlist);
            return ApiResponse.NotContent("Entidad modificada correctamente");
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var playlist = await _service.FindByIdAsync(id);
            if (playlist == null)
                return ApiResponse.NotFound("Entidad no encontrada");

            await _service.RemoveAsync(playlist);
            return ApiResponse.NotContent("Entidad eliminada correctamente");
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var playlist = await _service.FindByIdAsync(id);
            if (playlist == null)
                return ApiResponse.NotFound("Entidad no encontrada");

            return ApiResponse.Success("Entidad consultada correctamente", playlist);
        }

        [HttpGet("{id:guid}/songs")]
        public async Task<IActionResult> GetByIdWithSongs(Guid id)
        {
            var playlist = await _service.FindByIdWithSongsAsync(id);
            if (playlist == null)
                return ApiResponse.NotFound("Entidad no encontrada");

            return ApiResponse.Success("Entidad con relación consultada correctamente", playlist);
        }

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var playlists = await _service.FindAllAsync();
            return ApiResponse.Success("Lista de entidades", playlists);
        }

    }
}
