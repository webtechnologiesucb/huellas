using huellitas_api.Dtos;
using huellitas_api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace huellitas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacunasAplicadasController : ControllerBase
    {
        private readonly IVacunasAplicadaService _service;

        public VacunasAplicadasController(IVacunasAplicadaService service)
        {
            _service = service;
        }

        // GET: api/VacunasAplicadas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VacunasAplicadaDto>>> GetVacunasAplicadas()
        {
            return await _service.GetAll();
        }

        // GET: api/VacunasAplicadas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VacunasAplicadaDto>> GetVacunasAplicada(Guid id)
        {
            var vacuna = await _service.GetById(id);

            if (vacuna == null)
            {
                return NotFound();
            }

            return vacuna;
        }

        // PUT: api/VacunasAplicadas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVacunasAplicada(Guid id, VacunasAplicadaDto vacunaDto)
        {
            if (id != vacunaDto.Id)
            {
                return BadRequest();
            }

            var success = await _service.Update(id, vacunaDto);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/VacunasAplicadas
        [HttpPost]
        public async Task<ActionResult<VacunasAplicadaDto>> PostVacunasAplicada(VacunasAplicadaDto vacunaDto)
        {
            var success = await _service.Create(vacunaDto);
            if (!success)
            {
                return BadRequest();
            }

            return CreatedAtAction("GetVacunasAplicada", new { id = vacunaDto.Id }, vacunaDto);
        }

        // DELETE: api/VacunasAplicadas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVacunasAplicada(Guid id)
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
