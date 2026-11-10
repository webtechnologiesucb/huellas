using huellitas_api.Dtos;
using huellitas_api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace huellitas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpedientesClinicosController : ControllerBase
    {
        private readonly IExpedienteClinicoService _service;

        public ExpedientesClinicosController(IExpedienteClinicoService service)
        {
            _service = service;
        }

        // GET: api/ExpedientesClinicos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExpedienteClinicoDto>>> GetExpedienteClinicos()
        {
            return await _service.GetAll();
        }

        // GET: api/ExpedientesClinicos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExpedienteClinicoDto>> GetExpedienteClinico(Guid id)
        {
            var expediente = await _service.GetById(id);

            if (expediente == null)
            {
                return NotFound();
            }

            return expediente;
        }

        // PUT: api/ExpedientesClinicos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpedienteClinico(Guid id, ExpedienteClinicoDto expedienteDto)
        {
            if (id != expedienteDto.Id)
            {
                return BadRequest();
            }

            var success = await _service.Update(id, expedienteDto);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/ExpedientesClinicos
        [HttpPost]
        public async Task<ActionResult<ExpedienteClinicoDto>> PostExpedienteClinico(ExpedienteClinicoDto expedienteDto)
        {
            var success = await _service.Create(expedienteDto);
            if (!success)
            {
                return BadRequest();
            }

            return CreatedAtAction("GetExpedienteClinico", new { id = expedienteDto.Id }, expedienteDto);
        }

        // DELETE: api/ExpedientesClinicos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpedienteClinico(Guid id)
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
