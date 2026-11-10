using huellitas_api.Dtos;
using huellitas_api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace huellitas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfiguracionClinicaController : ControllerBase
    {
        private readonly IConfiguracionClinicaService _service;

        public ConfiguracionClinicaController(IConfiguracionClinicaService service)
        {
            _service = service;
        }

        // GET: api/ConfiguracionClinica
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConfiguracionClinicaDto>>> GetConfiguracionClinicas()
        {
            return await _service.GetAll();
        }

        // GET: api/ConfiguracionClinica/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConfiguracionClinicaDto>> GetConfiguracionClinica(int id)
        {
            var config = await _service.GetById(id);

            if (config == null)
            {
                return NotFound();
            }

            return config;
        }

        // PUT: api/ConfiguracionClinica/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConfiguracionClinica(int id, ConfiguracionClinicaDto configDto)
        {
            if (id != configDto.Id)
            {
                return BadRequest();
            }

            var success = await _service.Update(id, configDto);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/ConfiguracionClinica
        [HttpPost]
        public async Task<ActionResult<ConfiguracionClinicaDto>> PostConfiguracionClinica(ConfiguracionClinicaDto configDto)
        {
            var success = await _service.Create(configDto);
            if (!success)
            {
                return BadRequest();
            }

            return CreatedAtAction("GetConfiguracionClinica", new { id = configDto.Id }, configDto);
        }

        // DELETE: api/ConfiguracionClinica/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfiguracionClinica(int id)
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
