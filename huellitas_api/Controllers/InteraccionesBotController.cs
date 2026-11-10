using huellitas_api.Dtos;
using huellitas_api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace huellitas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InteraccionesBotController : ControllerBase
    {
        private readonly IInteraccionesBotService _service;

        public InteraccionesBotController(IInteraccionesBotService service)
        {
            _service = service;
        }

        // GET: api/InteraccionesBot
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InteraccionesBotDto>>> GetInteraccionesBots()
        {
            return await _service.GetAll();
        }

        // GET: api/InteraccionesBot/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InteraccionesBotDto>> GetInteraccionesBot(Guid id)
        {
            var interaccion = await _service.GetById(id);

            if (interaccion == null)
            {
                return NotFound();
            }

            return interaccion;
        }

        // PUT: api/InteraccionesBot/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInteraccionesBot(Guid id, InteraccionesBotDto interaccionDto)
        {
            if (id != interaccionDto.Id)
            {
                return BadRequest();
            }

            var success = await _service.Update(id, interaccionDto);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/InteraccionesBot
        [HttpPost]
        public async Task<ActionResult<InteraccionesBotDto>> PostInteraccionesBot(InteraccionesBotDto interaccionDto)
        {
            var success = await _service.Create(interaccionDto);
            if (!success)
            {
                return BadRequest();
            }

            return CreatedAtAction("GetInteraccionesBot", new { id = interaccionDto.Id }, interaccionDto);
        }

        // DELETE: api/InteraccionesBot/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInteraccionesBot(Guid id)
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
