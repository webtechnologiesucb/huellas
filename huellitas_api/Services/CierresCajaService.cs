using huellitas_api.Dtos;
using huellitas_api.Repositories.Interfaces;
using huellitas_api.Services.Interfaces;

namespace huellitas_api.Services
{
    public class CierresCajaService : ICierresCajaService
    {
        private readonly ICierresCajaRepository _repository;

        public CierresCajaService(ICierresCajaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CierresCajaDto>> GetAll() => await _repository.GetAll();
        public async Task<CierresCajaDto?> GetById(Guid id) => await _repository.GetById(id);
        public async Task<bool> Create(CierresCajaDto dto) => await _repository.Create(dto);
        public async Task<bool> Update(Guid id, CierresCajaDto dto) => await _repository.Update(id, dto);
        public async Task<bool> Delete(Guid id) => await _repository.Delete(id);
    }
}