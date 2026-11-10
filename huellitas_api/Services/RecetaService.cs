using huellitas_api.Dtos;
using huellitas_api.Repositories.Interfaces;
using huellitas_api.Services.Interfaces;

namespace huellitas_api.Services
{
    public class RecetaService : IRecetaService
    {
        private readonly IRecetaRepository _repository;

        public RecetaService(IRecetaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<RecetaDto>> GetAll() => await _repository.GetAll();
        public async Task<RecetaDto?> GetById(Guid id) => await _repository.GetById(id);
        public async Task<bool> Create(RecetaDto dto) => await _repository.Create(dto);
        public async Task<bool> Update(Guid id, RecetaDto dto) => await _repository.Update(id, dto);
        public async Task<bool> Delete(Guid id) => await _repository.Delete(id);
    }
}