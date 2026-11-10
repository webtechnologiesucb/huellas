using huellitas_api.Dtos;
using huellitas_api.Repositories.Interfaces;
using huellitas_api.Services.Interfaces;

namespace huellitas_api.Services
{
    public class LotesCaducidadService : ILotesCaducidadService
    {
        private readonly ILotesCaducidadRepository _repository;

        public LotesCaducidadService(ILotesCaducidadRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<LotesCaducidadDto>> GetAll() => await _repository.GetAll();
        public async Task<LotesCaducidadDto?> GetById(Guid id) => await _repository.GetById(id);
        public async Task<bool> Create(LotesCaducidadDto dto) => await _repository.Create(dto);
        public async Task<bool> Update(Guid id, LotesCaducidadDto dto) => await _repository.Update(id, dto);
        public async Task<bool> Delete(Guid id) => await _repository.Delete(id);
    }
}