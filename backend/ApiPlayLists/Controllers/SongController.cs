using ApiPlayLists.Models;
using ApiPlayLists.Services;
using ApiPlayLists.Utils;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPlayLists.Controllers
{

    [ApiController]
    [Route("api/songs")]
    [EnableCors("AllowAll")]
    public class SongController : ControllerBase
    {

        private readonly SongService _service;

        public SongController( SongService service ) => _service = service;

        // // !! Hacer Pruebas
        [HttpPost("testing")]
        public IActionResult Testing([FromBody] SongDto dto)
        {
            if(!ModelState.IsValid)
                return ApiResponse.BadRequest("Error en los campos", ModelState);

            return ApiResponse.Success("Cuerpo recibido correctamente", dto);
        }

        // // !! Crear una canción
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SongDto dto) 
        {
            if (!ModelState.IsValid)
                return ApiResponse.BadRequest("Error en los campos", ModelState);

            var song = await _service.CreateSong(dto);
            if (song == null) return ApiResponse.BadRequest("Entidad no creado");

            return ApiResponse.Created("Canción registrado correctament", song);

        }

        // // !! Modificar una canción
        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> Update(
            Guid id,
            [FromBody] SongDto dto
        ) {
            if (!ModelState.IsValid) return ApiResponse.BadRequest("El cuerpo está mal", ModelState);

            // Actualizar y verificar si se ha actualizado
            var updated = await _service.ModifySong(id, dto);
            if (updated == null) return ApiResponse.NotFound("Entidad no encontrada");

            return ApiResponse.NotContent("Entidad modificado correctamente", updated);
        }

        // // !! Eliminar una canción
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var song = await _service.DeleteSong(id);

            if (song == null) 
                return ApiResponse.NotFound("Entidad no encontrada");

            return ApiResponse.NotContent("Entidad eliminada correctamente", song);
        }

        // // !! Ver una canción
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> FindById(Guid id)
        {
            var song = await _service.FindByIdAsync(id);

            if (song == null)
                return ApiResponse.NotFound("Entidad no encontrada");

            return ApiResponse.Success("Entidad eliminada correctamente", song);
        }

        // // !! Lista de entidades
        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var songs = await _service.GetAll();

            return ApiResponse.Success("Lista de entidades", songs);
        }
        
    }

}
