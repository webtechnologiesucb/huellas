using huellitas_api.Dtos;
using huellitas_api.Repositories.Interfaces;
using huellitas_api.Services.Interfaces;

namespace huellitas_api.Services
{
    public class HorariosAtencionService : IHorariosAtencionService
    {
        private readonly IHorariosAtencionRepository _repository;

        public HorariosAtencionService(IHorariosAtencionRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<HorariosAtencionDto>> GetAll() => await _repository.GetAll();
        public async Task<HorariosAtencionDto?> GetById(Guid id) => await _repository.GetById(id);
        public async Task<bool> Create(HorariosAtencionDto dto) => await _repository.Create(dto);
        public async Task<bool> Update(Guid id, HorariosAtencionDto dto) => await _repository.Update(id, dto);
        public async Task<bool> Delete(Guid id) => await _repository.Delete(id);
    }
}