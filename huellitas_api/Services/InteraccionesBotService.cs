using huellitas_api.Dtos;
using huellitas_api.Repositories.Interfaces;
using huellitas_api.Services.Interfaces;

namespace huellitas_api.Services
{
    public class InteraccionesBotService : IInteraccionesBotService
    {
        private readonly IInteraccionesBotRepository _repository;

        public InteraccionesBotService(IInteraccionesBotRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<InteraccionesBotDto>> GetAll() => await _repository.GetAll();
        public async Task<InteraccionesBotDto?> GetById(Guid id) => await _repository.GetById(id);
        public async Task<bool> Create(InteraccionesBotDto dto) => await _repository.Create(dto);
        public async Task<bool> Update(Guid id, InteraccionesBotDto dto) => await _repository.Update(id, dto);
        public async Task<bool> Delete(Guid id) => await _repository.Delete(id);
    }
}