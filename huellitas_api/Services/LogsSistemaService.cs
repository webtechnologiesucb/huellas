using huellitas_api.Dtos;
using huellitas_api.Repositories.Interfaces;
using huellitas_api.Services.Interfaces;

namespace huellitas_api.Services
{
    public class LogsSistemaService : ILogsSistemaService
    {
        private readonly ILogsSistemaRepository _repository;

        public LogsSistemaService(ILogsSistemaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<LogsSistemaDto>> GetAll() => await _repository.GetAll();
        public async Task<LogsSistemaDto?> GetById(Guid id) => await _repository.GetById(id);
        public async Task<bool> Create(LogsSistemaDto dto) => await _repository.Create(dto);
        public async Task<bool> Update(Guid id, LogsSistemaDto dto) => await _repository.Update(id, dto);
        public async Task<bool> Delete(Guid id) => await _repository.Delete(id);
    }
}