using huellitas_api.Dtos;
using huellitas_api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace huellitas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LotesCaducidadController : ControllerBase
    {
        private readonly ILotesCaducidadService _service;

        public LotesCaducidadController(ILotesCaducidadService service)
        {
            _service = service;
        }

        // GET: api/LotesCaducidad
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LotesCaducidadDto>>> GetLotesCaducidads()
        {
            return await _service.GetAll();
        }

        // GET: api/LotesCaducidad/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LotesCaducidadDto>> GetLotesCaducidad(Guid id)
        {
            var lote = await _service.GetById(id);

            if (lote == null)
            {
                return NotFound();
            }

            return lote;
        }

        // PUT: api/LotesCaducidad/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLotesCaducidad(Guid id, LotesCaducidadDto loteDto)
        {
            if (id != loteDto.Id)
            {
                return BadRequest();
            }

            var success = await _service.Update(id, loteDto);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/LotesCaducidad
        [HttpPost]
        public async Task<ActionResult<LotesCaducidadDto>> PostLotesCaducidad(LotesCaducidadDto loteDto)
        {
            var success = await _service.Create(loteDto);
            if (!success)
            {
                return BadRequest();
            }

            return CreatedAtAction("GetLotesCaducidad", new { id = loteDto.Id }, loteDto);
        }

        // DELETE: api/LotesCaducidad/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLotesCaducidad(Guid id)
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
