using huellitas_api.Dtos;
using huellitas_api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace huellitas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArchivosAdjuntoController : ControllerBase
    {
        private readonly IArchivosAdjuntoService _service;

        public ArchivosAdjuntoController(IArchivosAdjuntoService service)
        {
            _service = service;
        }

        // GET: api/ArchivosAdjunto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArchivosAdjuntoDto>>> GetArchivosAdjuntos()
        {
            return await _service.GetAll();
        }

        // GET: api/ArchivosAdjunto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArchivosAdjuntoDto>> GetArchivosAdjunto(Guid id)
        {
            var archivo = await _service.GetById(id);

            if (archivo == null)
            {
                return NotFound();
            }

            return archivo;
        }

        // PUT: api/ArchivosAdjunto/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArchivosAdjunto(Guid id, ArchivosAdjuntoDto archivoDto)
        {
            if (id != archivoDto.Id)
            {
                return BadRequest();
            }

            var success = await _service.Update(id, archivoDto);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/ArchivosAdjunto
        [HttpPost]
        public async Task<ActionResult<ArchivosAdjuntoDto>> PostArchivosAdjunto(ArchivosAdjuntoDto archivoDto)
        {
            var success = await _service.Create(archivoDto);
            if (!success)
            {
                return BadRequest();
            }

            return CreatedAtAction("GetArchivosAdjunto", new { id = archivoDto.Id }, archivoDto);
        }

        // DELETE: api/ArchivosAdjunto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArchivosAdjunto(Guid id)
        {
            var success = await _service.Delete(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
