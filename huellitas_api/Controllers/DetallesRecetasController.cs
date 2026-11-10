using huellitas_api.Dtos;
using huellitas_api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace huellitas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallesRecetasController : ControllerBase
    {
        private readonly IDetallesRecetumService _service;

        public DetallesRecetasController(IDetallesRecetumService service)
        {
            _service = service;
        }

        // GET: api/DetallesRecetas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetallesRecetumDto>>> GetDetallesReceta()
        {
            return await _service.GetAll();
        }

        // GET: api/DetallesRecetas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetallesRecetumDto>> GetDetallesRecetum(Guid id)
        {
            var detalle = await _service.GetById(id);

            if (detalle == null)
            {
                return NotFound();
            }

            return detalle;
        }

        // PUT: api/DetallesRecetas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetallesRecetum(Guid id, DetallesRecetumDto detalleDto)
        {
            if (id != detalleDto.Id)
            {
                return BadRequest();
            }

            var success = await _service.Update(id, detalleDto);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/DetallesRecetas
        [HttpPost]
        public async Task<ActionResult<DetallesRecetumDto>> PostDetallesRecetum(DetallesRecetumDto detalleDto)
        {
            var success = await _service.Create(detalleDto);
            if (!success)
            {
                return BadRequest();
            }

            return CreatedAtAction("GetDetallesRecetum", new { id = detalleDto.Id }, detalleDto);
        }

        // DELETE: api/DetallesRecetas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetallesRecetum(Guid id)
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
