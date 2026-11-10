using huellitas_api.Dtos;
using huellitas_api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace huellitas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecetasController : ControllerBase
    {
        private readonly IRecetaService _service;

        public RecetasController(IRecetaService service)
        {
            _service = service;
        }

        // GET: api/Recetas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecetaDto>>> GetRecetas()
        {
            return await _service.GetAll();
        }

        // GET: api/Recetas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecetaDto>> GetReceta(Guid id)
        {
            var receta = await _service.GetById(id);

            if (receta == null)
            {
                return NotFound();
            }

            return receta;
        }

        // PUT: api/Recetas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReceta(Guid id, RecetaDto recetaDto)
        {
            if (id != recetaDto.Id)
            {
                return BadRequest();
            }

            var success = await _service.Update(id, recetaDto);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Recetas
        [HttpPost]
        public async Task<ActionResult<RecetaDto>> PostReceta(RecetaDto recetaDto)
        {
            var success = await _service.Create(recetaDto);
            if (!success)
            {
                return BadRequest();
            }

            return CreatedAtAction("GetReceta", new { id = recetaDto.Id }, recetaDto);
        }

        // DELETE: api/Recetas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReceta(Guid id)
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
