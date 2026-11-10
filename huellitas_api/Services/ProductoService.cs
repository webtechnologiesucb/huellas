using huellitas_api.Dtos;
using huellitas_api.Repositories.Interfaces;
using huellitas_api.Services.Interfaces;

namespace huellitas_api.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repository;

        public ProductoService(IProductoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProductoDto>> GetAll() => await _repository.GetAll();
        public async Task<ProductoDto?> GetById(Guid id) => await _repository.GetById(id);
        public async Task<bool> Create(ProductoDto dto) => await _repository.Create(dto);
        public async Task<bool> Update(Guid id, ProductoDto dto) => await _repository.Update(id, dto);
        public async Task<bool> Delete(Guid id) => await _repository.Delete(id);
    }
}