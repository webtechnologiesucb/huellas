using huellitas_api.Dtos;
using huellitas_api.Repositories.Interfaces;
using huellitas_api.Services.Interfaces;

namespace huellitas_api.Services
{
    public class CatalogoVacunaService : ICatalogoVacunaService
    {
        private readonly ICatalogoVacunaRepository _repository;

        public CatalogoVacunaService(ICatalogoVacunaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CatalogoVacunaDto>> GetAll() => await _repository.GetAll();
        public async Task<CatalogoVacunaDto?> GetById(int id) => await _repository.GetById(id);
        public async Task<bool> Create(CatalogoVacunaDto dto) => await _repository.Create(dto);
        public async Task<bool> Update(int id, CatalogoVacunaDto dto) => await _repository.Update(id, dto);
        public async Task<bool> Delete(int id) => await _repository.Delete(id);
    }
}