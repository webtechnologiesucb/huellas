using huellitas_api.Dtos;
using huellitas_api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace huellitas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaccionesCajaController : ControllerBase
    {
        private readonly ITransaccionesCajaService _service;

        public TransaccionesCajaController(ITransaccionesCajaService service)
        {
            _service = service;
        }

        // GET: api/TransaccionesCaja
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransaccionesCajaDto>>> GetTransaccionesCajas()
        {
            return await _service.GetAll();
        }

        // GET: api/TransaccionesCaja/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransaccionesCajaDto>> GetTransaccionesCaja(Guid id)
        {
            var transaccion = await _service.GetById(id);

            if (transaccion == null)
            {
                return NotFound();
            }

            return transaccion;
        }

        // PUT: api/TransaccionesCaja/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransaccionesCaja(Guid id, TransaccionesCajaDto transaccionDto)
        {
            if (id != transaccionDto.Id)
            {
                return BadRequest();
            }

            var success = await _service.Update(id, transaccionDto);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/TransaccionesCaja
        [HttpPost]
        public async Task<ActionResult<TransaccionesCajaDto>> PostTransaccionesCaja(TransaccionesCajaDto transaccionDto)
        {
            var success = await _service.Create(transaccionDto);
            if (!success)
            {
                return BadRequest();
            }

            return CreatedAtAction("GetTransaccionesCaja", new { id = transaccionDto.Id }, transaccionDto);
        }

        // DELETE: api/TransaccionesCaja/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaccionesCaja(Guid id)
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
