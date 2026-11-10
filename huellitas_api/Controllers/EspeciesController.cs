using huellitas_api.Dtos;
using huellitas_api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace huellitas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspeciesController : ControllerBase
    {
        private readonly IEspecyService _service;

        public EspeciesController(IEspecyService service)
        {
            _service = service;
        }

        // GET: api/Especies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EspecyDto>>> GetEspecies()
        {
            return await _service.GetAll();
        }

        // GET: api/Especies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EspecyDto>> GetEspecy(int id)
        {
            var especie = await _service.GetById(id);

            if (especie == null)
            {
                return NotFound();
            }

            return especie;
        }

        // PUT: api/Especies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEspecy(int id, EspecyDto especieDto)
        {
            if (id != especieDto.Id)
            {
                return BadRequest();
            }

            var success = await _service.Update(id, especieDto);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Especies
        [HttpPost]
        public async Task<ActionResult<EspecyDto>> PostEspecy(EspecyDto especieDto)
        {
            var success = await _service.Create(especieDto);
            if (!success)
            {
                return BadRequest();
            }

            return CreatedAtAction("GetEspecy", new { id = especieDto.Id }, especieDto);
        }

        // DELETE: api/Especies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEspecy(int id)
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
