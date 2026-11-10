using huellitas_api.Dtos;
using huellitas_api.Repositories.Interfaces;
using huellitas_api.Services.Interfaces;

namespace huellitas_api.Services
{
    public class HistorialClinicoService : IHistorialClinicoService
    {
        private readonly IHistorialClinicoRepository _repository;

        public HistorialClinicoService(IHistorialClinicoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<HistorialClinicoDto>> GetAll() => await _repository.GetAll();
        public async Task<HistorialClinicoDto?> GetById(Guid id) => await _repository.GetById(id);
        public async Task<bool> Create(HistorialClinicoDto dto) => await _repository.Create(dto);
        public async Task<bool> Update(Guid id, HistorialClinicoDto dto) => await _repository.Update(id, dto);
        public async Task<bool> Delete(Guid id) => await _repository.Delete(id);
    }
}