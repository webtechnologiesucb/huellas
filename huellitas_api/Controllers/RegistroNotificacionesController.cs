using huellitas_api.Dtos;
using huellitas_api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace huellitas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroNotificacionesController : ControllerBase
    {
        private readonly IRegistroNotificacioneService _service;

        public RegistroNotificacionesController(IRegistroNotificacioneService service)
        {
            _service = service;
        }

        // GET: api/RegistroNotificaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistroNotificacioneDto>>> GetRegistroNotificaciones()
        {
            return await _service.GetAll();
        }

        // GET: api/RegistroNotificaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegistroNotificacioneDto>> GetRegistroNotificacione(Guid id)
        {
            var notificacion = await _service.GetById(id);

            if (notificacion == null)
            {
                return NotFound();
            }

            return notificacion;
        }

        // PUT: api/RegistroNotificaciones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistroNotificacione(Guid id, RegistroNotificacioneDto notificacionDto)
        {
            if (id != notificacionDto.Id)
            {
                return BadRequest();
            }

            var success = await _service.Update(id, notificacionDto);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/RegistroNotificaciones
        [HttpPost]
        public async Task<ActionResult<RegistroNotificacioneDto>> PostRegistroNotificacione(RegistroNotificacioneDto notificacionDto)
        {
            var success = await _service.Create(notificacionDto);
            if (!success)
            {
                return BadRequest();
            }

            return CreatedAtAction("GetRegistroNotificacione", new { id = notificacionDto.Id }, notificacionDto);
        }

        // DELETE: api/RegistroNotificaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistroNotificacione(Guid id)
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
