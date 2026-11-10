using huellitas_api.Dtos;
using huellitas_api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace huellitas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroEscaneosQrController : ControllerBase
    {
        private readonly IRegistroEscaneosQrService _service;

        public RegistroEscaneosQrController(IRegistroEscaneosQrService service)
        {
            _service = service;
        }

        // GET: api/RegistroEscaneosQr
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistroEscaneosQrDto>>> GetRegistroEscaneosQrs()
        {
            return await _service.GetAll();
        }

        // GET: api/RegistroEscaneosQr/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegistroEscaneosQrDto>> GetRegistroEscaneosQr(Guid id)
        {
            var registro = await _service.GetById(id);

            if (registro == null)
            {
                return NotFound();
            }

            return registro;
        }

        // PUT: api/RegistroEscaneosQr/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistroEscaneosQr(Guid id, RegistroEscaneosQrDto registroDto)
        {
            if (id != registroDto.Id)
            {
                return BadRequest();
            }

            var success = await _service.Update(id, registroDto);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/RegistroEscaneosQr
        [HttpPost]
        public async Task<ActionResult<RegistroEscaneosQrDto>> PostRegistroEscaneosQr(RegistroEscaneosQrDto registroDto)
        {
            var success = await _service.Create(registroDto);
            if (!success)
            {
                return BadRequest();
            }

            return CreatedAtAction("GetRegistroEscaneosQr", new { id = registroDto.Id }, registroDto);
        }

        // DELETE: api/RegistroEscaneosQr/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistroEscaneosQr(Guid id)
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
