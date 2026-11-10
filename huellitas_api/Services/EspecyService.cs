using huellitas_api.Dtos;
using huellitas_api.Repositories.Interfaces;
using huellitas_api.Services.Interfaces;

namespace huellitas_api.Services
{
    public class EspecyService : IEspecyService
    {
        private readonly IEspecyRepository _repository;

        public EspecyService(IEspecyRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<EspecyDto>> GetAll() => await _repository.GetAll();
        public async Task<EspecyDto?> GetById(int id) => await _repository.GetById(id);
        public async Task<bool> Create(EspecyDto dto) => await _repository.Create(dto);
        public async Task<bool> Update(int id, EspecyDto dto) => await _repository.Update(id, dto);
        public async Task<bool> Delete(int id) => await _repository.Delete(id);
    }
}