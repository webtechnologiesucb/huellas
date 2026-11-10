using huellitas_api.Dtos;
using huellitas_api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace huellitas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalizacionInsumosController : ControllerBase
    {
        private readonly IHospitalizacionInsumoService _service;

        public HospitalizacionInsumosController(IHospitalizacionInsumoService service)
        {
            _service = service;
        }

        // GET: api/HospitalizacionInsumos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalizacionInsumoDto>>> GetHospitalizacionInsumos()
        {
            return await _service.GetAll();
        }

        // GET: api/HospitalizacionInsumos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalizacionInsumoDto>> GetHospitalizacionInsumo(Guid id)
        {
            var insumo = await _service.GetById(id);

            if (insumo == null)
            {
                return NotFound();
            }

            return insumo;
        }

        // PUT: api/HospitalizacionInsumos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalizacionInsumo(Guid id, HospitalizacionInsumoDto insumoDto)
        {
            if (id != insumoDto.Id)
            {
                return BadRequest();
            }

            var success = await _service.Update(id, insumoDto);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/HospitalizacionInsumos
        [HttpPost]
        public async Task<ActionResult<HospitalizacionInsumoDto>> PostHospitalizacionInsumo(HospitalizacionInsumoDto insumoDto)
        {
            var success = await _service.Create(insumoDto);
            if (!success)
            {
                return BadRequest();
            }

            return CreatedAtAction("GetHospitalizacionInsumo", new { id = insumoDto.Id }, insumoDto);
        }

        // DELETE: api/HospitalizacionInsumos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHospitalizacionInsumo(Guid id)
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
