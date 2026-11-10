using huellitas_api.Dtos;
using huellitas_api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace huellitas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CierresCajaController : ControllerBase
    {
        private readonly ICierresCajaService _service;

        public CierresCajaController(ICierresCajaService service)
        {
            _service = service;
        }

        // GET: api/CierresCaja
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CierresCajaDto>>> GetCierresCajas()
        {
            return await _service.GetAll();
        }

        // GET: api/CierresCaja/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CierresCajaDto>> GetCierresCaja(Guid id)
        {
            var cierre = await _service.GetById(id);

            if (cierre == null)
            {
                return NotFound();
            }

            return cierre;
        }

        // PUT: api/CierresCaja/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCierresCaja(Guid id, CierresCajaDto cierreDto)
        {
            if (id != cierreDto.Id)
            {
                return BadRequest();
            }

            var success = await _service.Update(id, cierreDto);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/CierresCaja
        [HttpPost]
        public async Task<ActionResult<CierresCajaDto>> PostCierresCaja(CierresCajaDto cierreDto)
        {
            var success = await _service.Create(cierreDto);
            if (!success)
            {
                return BadRequest();
            }

            return CreatedAtAction("GetCierresCaja", new { id = cierreDto.Id }, cierreDto);
        }

        // DELETE: api/CierresCaja/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCierresCaja(Guid id)
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
