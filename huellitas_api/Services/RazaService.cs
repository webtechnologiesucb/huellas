using huellitas_api.Dtos;
using huellitas_api.Repositories.Interfaces;
using huellitas_api.Services.Interfaces;

namespace huellitas_api.Services
{
    public class RazaService : IRazaService
    {
        private readonly IRazaRepository _repository;

        public RazaService(IRazaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<RazaDto>> GetAll() => await _repository.GetAll();
        public async Task<RazaDto?> GetById(int id) => await _repository.GetById(id);
        public async Task<bool> Create(RazaDto dto) => await _repository.Create(dto);
        public async Task<bool> Update(int id, RazaDto dto) => await _repository.Update(id, dto);
        public async Task<bool> Delete(int id) => await _repository.Delete(id);
    }
}