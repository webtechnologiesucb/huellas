using huellitas_api.Dtos;
using huellitas_api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace huellitas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorariosAtencionController : ControllerBase
    {
        private readonly IHorariosAtencionService _service;

        public HorariosAtencionController(IHorariosAtencionService service)
        {
            _service = service;
        }

        // GET: api/HorariosAtencion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HorariosAtencionDto>>> GetHorariosAtencions()
        {
            return await _service.GetAll();
        }

        // GET: api/HorariosAtencion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HorariosAtencionDto>> GetHorariosAtencion(Guid id)
        {
            var horario = await _service.GetById(id);

            if (horario == null)
            {
                return NotFound();
            }

            return horario;
        }

        // PUT: api/HorariosAtencion/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHorariosAtencion(Guid id, HorariosAtencionDto horarioDto)
        {
            if (id != horarioDto.Id)
            {
                return BadRequest();
            }

            var success = await _service.Update(id, horarioDto);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/HorariosAtencion
        [HttpPost]
        public async Task<ActionResult<HorariosAtencionDto>> PostHorariosAtencion(HorariosAtencionDto horarioDto)
        {
            var success = await _service.Create(horarioDto);
            if (!success)
            {
                return BadRequest();
            }

            return CreatedAtAction("GetHorariosAtencion", new { id = horarioDto.Id }, horarioDto);
        }

        // DELETE: api/HorariosAtencion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHorariosAtencion(Guid id)
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
