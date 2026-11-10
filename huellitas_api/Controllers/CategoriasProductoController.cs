using huellitas_api.Dtos;
using huellitas_api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace huellitas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasProductoController : ControllerBase
    {
        private readonly ICategoriasProductoService _service;

        public CategoriasProductoController(ICategoriasProductoService service)
        {
            _service = service;
        }

        // GET: api/CategoriasProducto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriasProductoDto>>> GetCategoriasProductos()
        {
            return await _service.GetAll();
        }

        // GET: api/CategoriasProducto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriasProductoDto>> GetCategoriasProducto(int id)
        {
            var categoria = await _service.GetById(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return categoria;
        }

        // PUT: api/CategoriasProducto/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoriasProducto(int id, CategoriasProductoDto categoriaDto)
        {
            if (id != categoriaDto.Id)
            {
                return BadRequest();
            }

            var success = await _service.Update(id, categoriaDto);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/CategoriasProducto
        [HttpPost]
        public async Task<ActionResult<CategoriasProductoDto>> PostCategoriasProducto(CategoriasProductoDto categoriaDto)
        {
            var success = await _service.Create(categoriaDto);
            if (!success)
            {
                return BadRequest();
            }

            return CreatedAtAction("GetCategoriasProducto", new { id = categoriaDto.Id }, categoriaDto);
        }

        // DELETE: api/CategoriasProducto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoriasProducto(int id)
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
