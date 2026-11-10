using huellitas_api.Dtos;
using huellitas_api.Repositories.Interfaces;
using huellitas_api.Services.Interfaces;

namespace huellitas_api.Services
{
    public class HospitalizacionInsumoService : IHospitalizacionInsumoService
    {
        private readonly IHospitalizacionInsumoRepository _repository;

        public HospitalizacionInsumoService(IHospitalizacionInsumoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<HospitalizacionInsumoDto>> GetAll() => await _repository.GetAll();
        public async Task<HospitalizacionInsumoDto?> GetById(Guid id) => await _repository.GetById(id);
        public async Task<bool> Create(HospitalizacionInsumoDto dto) => await _repository.Create(dto);
        public async Task<bool> Update(Guid id, HospitalizacionInsumoDto dto) => await _repository.Update(id, dto);
        public async Task<bool> Delete(Guid id) => await _repository.Delete(id);
    }
}