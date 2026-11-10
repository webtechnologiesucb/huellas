using huellitas_api.Dtos;
using huellitas_api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace huellitas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallesTransaccionController : ControllerBase
    {
        private readonly IDetallesTransaccionService _service;

        public DetallesTransaccionController(IDetallesTransaccionService service)
        {
            _service = service;
        }

        // GET: api/DetallesTransaccion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetallesTransaccionDto>>> GetDetallesTransaccions()
        {
            return await _service.GetAll();
        }

        // GET: api/DetallesTransaccion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetallesTransaccionDto>> GetDetallesTransaccion(Guid id)
        {
            var detalle = await _service.GetById(id);

            if (detalle == null)
            {
                return NotFound();
            }

            return detalle;
        }

        // PUT: api/DetallesTransaccion/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetallesTransaccion(Guid id, DetallesTransaccionDto detalleDto)
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

        // POST: api/DetallesTransaccion
        [HttpPost]
        public async Task<ActionResult<DetallesTransaccionDto>> PostDetallesTransaccion(DetallesTransaccionDto detalleDto)
        {
            var success = await _service.Create(detalleDto);
            if (!success)
            {
                return BadRequest();
            }

            return CreatedAtAction("GetDetallesTransaccion", new { id = detalleDto.Id }, detalleDto);
        }

        // DELETE: api/DetallesTransaccion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetallesTransaccion(Guid id)
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
