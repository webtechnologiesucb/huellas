using huellitas_api.Dtos;
using huellitas_api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace huellitas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalizacionesController : ControllerBase
    {
        private readonly IHospitalizacioneService _service;

        public HospitalizacionesController(IHospitalizacioneService service)
        {
            _service = service;
        }

        // GET: api/Hospitalizaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalizacioneDto>>> GetHospitalizaciones()
        {
            return await _service.GetAll();
        }

        // GET: api/Hospitalizaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalizacioneDto>> GetHospitalizacione(Guid id)
        {
            var hospitalizacion = await _service.GetById(id);

            if (hospitalizacion == null)
            {
                return NotFound();
            }

            return hospitalizacion;
        }

        // PUT: api/Hospitalizaciones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalizacione(Guid id, HospitalizacioneDto hospitalizacionDto)
        {
            if (id != hospitalizacionDto.Id)
            {
                return BadRequest();
            }

            var success = await _service.Update(id, hospitalizacionDto);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Hospitalizaciones
        [HttpPost]
        public async Task<ActionResult<HospitalizacioneDto>> PostHospitalizacione(HospitalizacioneDto hospitalizacionDto)
        {
            var success = await _service.Create(hospitalizacionDto);
            if (!success)
            {
                return BadRequest();
            }

            return CreatedAtAction("GetHospitalizacione", new { id = hospitalizacionDto.Id }, hospitalizacionDto);
        }

        // DELETE: api/Hospitalizaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHospitalizacione(Guid id)
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
