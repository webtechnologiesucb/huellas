using huellitas_api.Dtos;
using huellitas_api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace huellitas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialesClinicosController : ControllerBase
    {
        private readonly IHistorialClinicoService _service;

        public HistorialesClinicosController(IHistorialClinicoService service)
        {
            _service = service;
        }

        // GET: api/HistorialesClinicos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistorialClinicoDto>>> GetHistorialClinicos()
        {
            return await _service.GetAll();
        }

        // GET: api/HistorialesClinicos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HistorialClinicoDto>> GetHistorialClinico(Guid id)
        {
            var historial = await _service.GetById(id);

            if (historial == null)
            {
                return NotFound();
            }

            return historial;
        }

        // PUT: api/HistorialesClinicos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistorialClinico(Guid id, HistorialClinicoDto historialDto)
        {
            if (id != historialDto.Id)
            {
                return BadRequest();
            }

            var success = await _service.Update(id, historialDto);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/HistorialesClinicos
        [HttpPost]
        public async Task<ActionResult<HistorialClinicoDto>> PostHistorialClinico(HistorialClinicoDto historialDto)
        {
            var success = await _service.Create(historialDto);
            if (!success)
            {
                return BadRequest();
            }

            return CreatedAtAction("GetHistorialClinico", new { id = historialDto.Id }, historialDto);
        }

        // DELETE: api/HistorialesClinicos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistorialClinico(Guid id)
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
