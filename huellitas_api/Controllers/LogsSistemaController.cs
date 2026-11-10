using huellitas_api.Dtos;
using huellitas_api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace huellitas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsSistemaController : ControllerBase
    {
        private readonly ILogsSistemaService _service;

        public LogsSistemaController(ILogsSistemaService service)
        {
            _service = service;
        }

        // GET: api/LogsSistema
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogsSistemaDto>>> GetLogsSistemas()
        {
            return await _service.GetAll();
        }

        // GET: api/LogsSistema/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LogsSistemaDto>> GetLogsSistema(Guid id)
        {
            var log = await _service.GetById(id);

            if (log == null)
            {
                return NotFound();
            }

            return log;
        }

        // PUT: api/LogsSistema/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogsSistema(Guid id, LogsSistemaDto logDto)
        {
            if (id != logDto.Id)
            {
                return BadRequest();
            }

            var success = await _service.Update(id, logDto);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/LogsSistema
        [HttpPost]
        public async Task<ActionResult<LogsSistemaDto>> PostLogsSistema(LogsSistemaDto logDto)
        {
            var success = await _service.Create(logDto);
            if (!success)
            {
                return BadRequest();
            }

            return CreatedAtAction("GetLogsSistema", new { id = logDto.Id }, logDto);
        }

        // DELETE: api/LogsSistema/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogsSistema(Guid id)
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
