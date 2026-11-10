using huellitas_api.Dtos;
using huellitas_api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace huellitas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogoVacunasController : ControllerBase
    {
        private readonly ICatalogoVacunaService _service;

        public CatalogoVacunasController(ICatalogoVacunaService service)
        {
            _service = service;
        }

        // GET: api/CatalogoVacunas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatalogoVacunaDto>>> GetCatalogoVacunas()
        {
            return await _service.GetAll();
        }

        // GET: api/CatalogoVacunas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CatalogoVacunaDto>> GetCatalogoVacuna(int id)
        {
            var vacuna = await _service.GetById(id);

            if (vacuna == null)
            {
                return NotFound();
            }

            return vacuna;
        }

        // PUT: api/CatalogoVacunas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatalogoVacuna(int id, CatalogoVacunaDto vacunaDto)
        {
            if (id != vacunaDto.Id)
            {
                return BadRequest();
            }

            var success = await _service.Update(id, vacunaDto);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/CatalogoVacunas
        [HttpPost]
        public async Task<ActionResult<CatalogoVacunaDto>> PostCatalogoVacuna(CatalogoVacunaDto vacunaDto)
        {
            var success = await _service.Create(vacunaDto);
            if (!success)
            {
                return BadRequest();
            }

            return CreatedAtAction("GetCatalogoVacuna", new { id = vacunaDto.Id }, vacunaDto);
        }

        // DELETE: api/CatalogoVacunas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCatalogoVacuna(int id)
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
