using huellitas_api.Dtos;
using huellitas_api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace huellitas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RazasController : ControllerBase
    {
        private readonly IRazaService _service;

        public RazasController(IRazaService service)
        {
            _service = service;
        }

        // GET: api/Razas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RazaDto>>> GetRazas()
        {
            return await _service.GetAll();
        }

        // GET: api/Razas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RazaDto>> GetRaza(int id)
        {
            var raza = await _service.GetById(id);

            if (raza == null)
            {
                return NotFound();
            }

            return raza;
        }

        // PUT: api/Razas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRaza(int id, RazaDto razaDto)
        {
            if (id != razaDto.Id)
            {
                return BadRequest();
            }

            var success = await _service.Update(id, razaDto);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Razas
        [HttpPost]
        public async Task<ActionResult<RazaDto>> PostRaza(RazaDto razaDto)
        {
            var success = await _service.Create(razaDto);
            if (!success)
            {
                return BadRequest();
            }

            return CreatedAtAction("GetRaza", new { id = razaDto.Id }, razaDto);
        }

        // DELETE: api/Razas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRaza(int id)
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
