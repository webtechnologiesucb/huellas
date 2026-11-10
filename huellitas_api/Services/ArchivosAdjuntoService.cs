using huellitas_api.Dtos;
using huellitas_api.Repositories.Interfaces;
using huellitas_api.Services.Interfaces;

namespace huellitas_api.Services
{
    public class ArchivosAdjuntoService : IArchivosAdjuntoService
    {
        private readonly IArchivosAdjuntoRepository _repository;

        public ArchivosAdjuntoService(IArchivosAdjuntoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ArchivosAdjuntoDto>> GetAll() => await _repository.GetAll();
        public async Task<ArchivosAdjuntoDto?> GetById(Guid id) => await _repository.GetById(id);
        public async Task<bool> Create(ArchivosAdjuntoDto dto) => await _repository.Create(dto);
        public async Task<bool> Update(Guid id, ArchivosAdjuntoDto dto) => await _repository.Update(id, dto);
        public async Task<bool> Delete(Guid id) => await _repository.Delete(id);
    }
}