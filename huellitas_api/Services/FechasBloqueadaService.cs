using huellitas_api.Dtos;
using huellitas_api.Repositories.Interfaces;
using huellitas_api.Services.Interfaces;

namespace huellitas_api.Services
{
    public class FechasBloqueadaService : IFechasBloqueadaService
    {
        private readonly IFechasBloqueadaRepository _repository;

        public FechasBloqueadaService(IFechasBloqueadaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<FechasBloqueadaDto>> GetAll() => await _repository.GetAll();
        public async Task<FechasBloqueadaDto?> GetById(Guid id) => await _repository.GetById(id);
        public async Task<bool> Create(FechasBloqueadaDto dto) => await _repository.Create(dto);
        public async Task<bool> Update(Guid id, FechasBloqueadaDto dto) => await _repository.Update(id, dto);
        public async Task<bool> Delete(Guid id) => await _repository.Delete(id);
    }
}