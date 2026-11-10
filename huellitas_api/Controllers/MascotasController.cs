using huellitas_api.Dtos;
using huellitas_api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace huellitas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MascotasController : ControllerBase
    {
        private readonly IMascotasService _service;

        public MascotasController(IMascotasService service)
        {
            _service = service;
        }

        // GET: api/Mascotas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MascotaDto>>> GetMascotas()
        {
            return await _service.GetAll();
        }

        // GET: api/Mascotas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MascotaDto>> GetMascota(Guid id)
        {
            var mascota = await _service.GetById(id);

            if (mascota == null)
            {
                return NotFound();
            }

            return mascota;
        }

        // PUT: api/Mascotas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMascota(Guid id, MascotaDto mascotaDto)
        {
            if (id != mascotaDto.Id)
            {
                return BadRequest();
            }

            var success = await _service.Update(id, mascotaDto);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Mascotas
        [HttpPost]
        public async Task<ActionResult<MascotaDto>> PostMascota(MascotaDto mascotaDto)
        {
            var success = await _service.Create(mascotaDto);
            if (!success)
            {
                return BadRequest();
            }

            return CreatedAtAction("GetMascota", new { id = mascotaDto.Id }, mascotaDto);
        }

        // DELETE: api/Mascotas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMascota(Guid id)
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
