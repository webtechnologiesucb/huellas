using huellitas_api.Dtos;
using huellitas_api.Repositories.Interfaces;
using huellitas_api.Services.Interfaces;

namespace huellitas_api.Services
{
    public class ExpedienteClinicoService : IExpedienteClinicoService
    {
        private readonly IExpedienteClinicoRepository _repository;

        public ExpedienteClinicoService(IExpedienteClinicoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ExpedienteClinicoDto>> GetAll() => await _repository.GetAll();
        public async Task<ExpedienteClinicoDto?> GetById(Guid id) => await _repository.GetById(id);
        public async Task<bool> Create(ExpedienteClinicoDto dto) => await _repository.Create(dto);
        public async Task<bool> Update(Guid id, ExpedienteClinicoDto dto) => await _repository.Update(id, dto);
        public async Task<bool> Delete(Guid id) => await _repository.Delete(id);
    }
}