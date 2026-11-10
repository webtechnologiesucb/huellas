using huellitas_api.Dtos;
using huellitas_api.Repositories.Interfaces;
using huellitas_api.Services.Interfaces;

namespace huellitas_api.Services
{
    public class HospitalizacioneService : IHospitalizacioneService
    {
        private readonly IHospitalizacioneRepository _repository;

        public HospitalizacioneService(IHospitalizacioneRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<HospitalizacioneDto>> GetAll() => await _repository.GetAll();
        public async Task<HospitalizacioneDto?> GetById(Guid id) => await _repository.GetById(id);
        public async Task<bool> Create(HospitalizacioneDto dto) => await _repository.Create(dto);
        public async Task<bool> Update(Guid id, HospitalizacioneDto dto) => await _repository.Update(id, dto);
        public async Task<bool> Delete(Guid id) => await _repository.Delete(id);
    }
}