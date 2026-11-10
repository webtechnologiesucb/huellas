using huellitas_api.Dtos;
using huellitas_api.Repositories.Interfaces;
using huellitas_api.Services.Interfaces;

namespace huellitas_api.Services
{
    public class TransaccionesCajaService : ITransaccionesCajaService
    {
        private readonly ITransaccionesCajaRepository _repository;

        public TransaccionesCajaService(ITransaccionesCajaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TransaccionesCajaDto>> GetAll() => await _repository.GetAll();
        public async Task<TransaccionesCajaDto?> GetById(Guid id) => await _repository.GetById(id);
        public async Task<bool> Create(TransaccionesCajaDto dto) => await _repository.Create(dto);
        public async Task<bool> Update(Guid id, TransaccionesCajaDto dto) => await _repository.Update(id, dto);
        public async Task<bool> Delete(Guid id) => await _repository.Delete(id);
    }
}