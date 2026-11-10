using huellitas_api.Dtos;
using huellitas_api.Repositories.Interfaces;
using huellitas_api.Services.Interfaces;

namespace huellitas_api.Services
{
    public class MascotasService : IMascotasService
    {
        private readonly IMascotasRepository _repository;

        public MascotasService(IMascotasRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<MascotaDto>> GetAll() => await _repository.GetAll();
        public async Task<MascotaDto?> GetById(Guid id) => await _repository.GetById(id);
        public async Task<bool> Create(MascotaDto dto) => await _repository.Create(dto);
        public async Task<bool> Update(Guid id, MascotaDto dto) => await _repository.Update(id, dto);
        public async Task<bool> Delete(Guid id) => await _repository.Delete(id);
    }
}