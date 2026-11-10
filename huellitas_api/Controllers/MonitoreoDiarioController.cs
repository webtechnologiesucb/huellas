using huellitas_api.Dtos;
using huellitas_api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace huellitas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonitoreoDiarioController : ControllerBase
    {
        private readonly IMonitoreoDiarioService _service;

        public MonitoreoDiarioController(IMonitoreoDiarioService service)
        {
            _service = service;
        }

        // GET: api/MonitoreoDiario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MonitoreoDiarioDto>>> GetMonitoreoDiarios()
        {
            return await _service.GetAll();
        }

        // GET: api/MonitoreoDiario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MonitoreoDiarioDto>> GetMonitoreoDiario(Guid id)
        {
            var monitoreo = await _service.GetById(id);

            if (monitoreo == null)
            {
                return NotFound();
            }

            return monitoreo;
        }

        // PUT: api/MonitoreoDiario/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMonitoreoDiario(Guid id, MonitoreoDiarioDto monitoreoDto)
        {
            if (id != monitoreoDto.Id)
            {
                return BadRequest();
            }

            var success = await _service.Update(id, monitoreoDto);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/MonitoreoDiario
        [HttpPost]
        public async Task<ActionResult<MonitoreoDiarioDto>> PostMonitoreoDiario(MonitoreoDiarioDto monitoreoDto)
        {
            var success = await _service.Create(monitoreoDto);
            if (!success)
            {
                return BadRequest();
            }

            return CreatedAtAction("GetMonitoreoDiario", new { id = monitoreoDto.Id }, monitoreoDto);
        }

        // DELETE: api/MonitoreoDiario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMonitoreoDiario(Guid id)
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
