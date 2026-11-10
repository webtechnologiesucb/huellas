using huellitas_api.Dtos;
using huellitas_api.Repositories.Interfaces;
using huellitas_api.Services.Interfaces;

namespace huellitas_api.Services
{
    public class CitaService : ICitaService
    {
        private readonly ICitaRepository _repository;

        public CitaService(ICitaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CitaDto>> GetAll() => await _repository.GetAll();
        public async Task<CitaDto?> GetById(Guid id) => await _repository.GetById(id);
        public async Task<bool> Create(CitaDto dto) => await _repository.Create(dto);
        public async Task<bool> Update(Guid id, CitaDto dto) => await _repository.Update(id, dto);
        public async Task<bool> Delete(Guid id) => await _repository.Delete(id);
    }
}