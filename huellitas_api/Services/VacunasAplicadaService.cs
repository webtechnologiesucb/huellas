using huellitas_api.Dtos;
using huellitas_api.Repositories.Interfaces;
using huellitas_api.Services.Interfaces;

namespace huellitas_api.Services
{
    public class VacunasAplicadaService : IVacunasAplicadaService
    {
        private readonly IVacunasAplicadaRepository _repository;

        public VacunasAplicadaService(IVacunasAplicadaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<VacunasAplicadaDto>> GetAll() => await _repository.GetAll();
        public async Task<VacunasAplicadaDto?> GetById(Guid id) => await _repository.GetById(id);
        public async Task<bool> Create(VacunasAplicadaDto dto) => await _repository.Create(dto);
        public async Task<bool> Update(Guid id, VacunasAplicadaDto dto) => await _repository.Update(id, dto);
        public async Task<bool> Delete(Guid id) => await _repository.Delete(id);
    }
}