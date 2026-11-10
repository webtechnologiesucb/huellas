using huellitas_api.Dtos;
using huellitas_api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace huellitas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KardexInventarioController : ControllerBase
    {
        private readonly IKardexInventarioService _service;

        public KardexInventarioController(IKardexInventarioService service)
        {
            _service = service;
        }

        // GET: api/KardexInventario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KardexInventarioDto>>> GetKardexInventarios()
        {
            return await _service.GetAll();
        }

        // GET: api/KardexInventario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KardexInventarioDto>> GetKardexInventario(Guid id)
        {
            var kardex = await _service.GetById(id);

            if (kardex == null)
            {
                return NotFound();
            }

            return kardex;
        }

        // PUT: api/KardexInventario/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKardexInventario(Guid id, KardexInventarioDto kardexDto)
        {
            if (id != kardexDto.Id)
            {
                return BadRequest();
            }

            var success = await _service.Update(id, kardexDto);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/KardexInventario
        [HttpPost]
        public async Task<ActionResult<KardexInventarioDto>> PostKardexInventario(KardexInventarioDto kardexDto)
        {
            var success = await _service.Create(kardexDto);
            if (!success)
            {
                return BadRequest();
            }

            return CreatedAtAction("GetKardexInventario", new { id = kardexDto.Id }, kardexDto);
        }

        // DELETE: api/KardexInventario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKardexInventario(Guid id)
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
