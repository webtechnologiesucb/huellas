using huellitas_api.Dtos;
using huellitas_api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace huellitas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FechasBloqueadasController : ControllerBase
    {
        private readonly IFechasBloqueadaService _service;

        public FechasBloqueadasController(IFechasBloqueadaService service)
        {
            _service = service;
        }

        // GET: api/FechasBloqueadas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FechasBloqueadaDto>>> GetFechasBloqueadas()
        {
            return await _service.GetAll();
        }

        // GET: api/FechasBloqueadas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FechasBloqueadaDto>> GetFechasBloqueada(Guid id)
        {
            var fecha = await _service.GetById(id);

            if (fecha == null)
            {
                return NotFound();
            }

            return fecha;
        }

        // PUT: api/FechasBloqueadas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFechasBloqueada(Guid id, FechasBloqueadaDto fechaDto)
        {
            if (id != fechaDto.Id)
            {
                return BadRequest();
            }

            var success = await _service.Update(id, fechaDto);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/FechasBloqueadas
        [HttpPost]
        public async Task<ActionResult<FechasBloqueadaDto>> PostFechasBloqueada(FechasBloqueadaDto fechaDto)
        {
            var success = await _service.Create(fechaDto);
            if (!success)
            {
                return BadRequest();
            }

            return CreatedAtAction("GetFechasBloqueada", new { id = fechaDto.Id }, fechaDto);
        }

        // DELETE: api/FechasBloqueadas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFechasBloqueada(Guid id)
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
